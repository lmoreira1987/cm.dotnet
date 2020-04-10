using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace VSTS.Client
{
	internal static class Program
	{
		private static readonly string Uri;
		private static readonly string PersonalAccessToken;

		static Program()
		{
			Uri = "";                   // e.g. https://xxxxx.visualstudio.com
            PersonalAccessToken = "";   // can acquire in vsts online
		}

		private static void Main(string[] args)
		{
            // Set uri
            var accountUri = new Uri(Uri);

            // Create a connection to the account
            var connection = new VssConnection(accountUri, new VssBasicCredential(string.Empty, PersonalAccessToken));

			// Get an instance of the work item tracking client
			var witClient = connection.GetClient<WorkItemTrackingHttpClient>();

		    do
		    {
		        try
		        {
		            Console.Write(Environment.NewLine);
		            var testSuite = new StringBuilder();

		            // Start the console with the option to choose the user story
		            var workItemRead = ChooseUserStory();

		            // Set User Story ID
		            var userStoryId = int.Parse(workItemRead ?? throw new InvalidOperationException());

		            GetTestSuite(witClient, userStoryId, testSuite);
		            Console.Write("Deseja buscar novamente (s/n): ");
                }
		        catch (Exception)
		        {
		            Console.WriteLine("Caracter inválido. Deseja tentar novamente (s/n): ");
		        }
                
		    } while (Console.ReadLine().ToLower() == "s");
		}

	    private static void GetTestSuite(WorkItemTrackingHttpClient witClient, int userStoryId, StringBuilder testSuite)
	    {
	        try
	        {
	            var userStoryWorkitem = witClient.GetWorkItemAsync(userStoryId, expand: WorkItemExpand.Relations).Result;
	            //Console.WriteLine(Environment.NewLine);

	            var query = (from r in userStoryWorkitem.Relations
	                    where r.Rel.Equals("Microsoft.VSTS.Common.TestedBy-Forward")
	                    select r
	                ).OrderBy(o => o.Url)
	                .ToList();

	            //Console.WriteLine("******");
	            testSuite.AppendLine("-------------------------------------------------------------------------------------------------------");

	            //Console.WriteLine("US {0}: {1}", userStoryId, userStoryWorkitem.Fields["System.Title"]);
	            testSuite.AppendLine($"US {userStoryId}: {userStoryWorkitem.Fields["System.Title"]}");
	            testSuite.AppendLine(Environment.NewLine);
                testSuite.AppendLine("Description: ");
	            testSuite.AppendLine($"{ReplaceHtmlTags(userStoryWorkitem.Fields["System.Description"].ToString())}");

                //Console.WriteLine("******\n");
                testSuite.AppendLine("-------------------------------------------------------------------------------------------------------");
	            testSuite.AppendLine(Environment.NewLine);

	            foreach (var item in query)
	            {
	                var splittedUrl = item.Url.Split('/');
	                var idTestCase = splittedUrl[splittedUrl.Length - 1];
	                var result = witClient.GetWorkItemAsync(Convert.ToInt32(idTestCase)).Result;

	                testSuite.AppendLine("-------------------------------------------------------------------------------------------------------");
	                //Console.WriteLine("ID: {0}", idTestCase);
	                testSuite.AppendLine($"ID: {idTestCase}");

	                //Console.WriteLine("Title: {0}", result.Fields["System.Title"]);
	                testSuite.AppendLine($"Title: {result.Fields["System.Title"]}");


	                //Console.WriteLine("Region: {0}", result.Fields["DominosScrum.Region"]);
	                testSuite.AppendLine($"Region: {result.Fields["DominosScrum.Region"]}");

	                WriteSteps(result, testSuite);

	                WriteParameterValues(result, testSuite);

	                //Console.WriteLine("");
	                testSuite.AppendLine(Environment.NewLine);
	            }

	            using (var writer = new StreamWriter($"C:\\Temp\\US {userStoryId}.txt"))
	            {
	                writer.WriteLine(testSuite);
	            }

	            Console.WriteLine("DONE!");
	            //Console.Read();
	        }
	        catch (AggregateException aex)
	        {
	            if (aex.InnerException is VssServiceException vssex)
	            {
	                Console.WriteLine(vssex.Message);
	            }
	        }
	    }

	    private static void WriteParameterValues(WorkItem workItem, StringBuilder testSuite)
	    {
	        var xml = workItem.Fields["Microsoft.VSTS.TCM.LocalDataSource"].ToString();
	        var xmlDoc = new XmlDocument();
	        xmlDoc.LoadXml(xml);

	        var table = xmlDoc.GetElementsByTagName("Table1");
	        testSuite.AppendLine("***** Parameter Values *****");

            foreach (var tableRow in table)
	        {
	            foreach (XmlNode childNode in ((XmlNode)tableRow).ChildNodes)
	            {
	                //Console.WriteLine(childNode.InnerText);
	                testSuite.AppendLine($"{childNode.LocalName} = {ReplaceHtmlTags(childNode.InnerText)}");
                }

	            testSuite.AppendLine(Environment.NewLine);
            }
	    }

        private static void WriteSteps(WorkItem workItem, StringBuilder testSuite)
	    {
	        var xml = workItem.Fields["Microsoft.VSTS.TCM.Steps"].ToString();
	        var xmlDoc = new XmlDocument();
	        xmlDoc.LoadXml(xml);

	        var result = FromXml<steps>(xmlDoc.InnerXml);
	        //Console.WriteLine("***** Steps *****");
	        testSuite.AppendLine("***** Steps *****");

	        int count = 1;
	        foreach (var step in result.step)
	        {
	            testSuite.AppendLine($"{count}) -------------");
                foreach (var item in step.parameterizedString)
                {
                    //Console.Write($"{item.Value}\t");
                    var replacedItem = ReplaceHtmlTags(item.Value);

                    testSuite.AppendLine($"{replacedItem}");
                }

	            //Console.WriteLine();
	            testSuite.AppendLine(Environment.NewLine);
	            count++;
	        }
	    }

	    private static string ReplaceHtmlTags(string item)
	    {
	        return item
	            .Replace("<BR/>", Environment.NewLine) 
	            .Replace("<BR />", Environment.NewLine)
	            .Replace("<BR>", Environment.NewLine)
	            .Replace("<P>", "")
	            .Replace("</P>", "")
	            .Replace("<DIV>", "")
	            .Replace("</DIV>", "")
	            .Replace("<br/>", Environment.NewLine)
                .Replace("<br />", Environment.NewLine)
                .Replace("<br>", Environment.NewLine)
                .Replace("<p>", "")
	            .Replace("</p>", "")
	            .Replace("<div>", "")
	            .Replace("</div>", "")
                .Replace("&quot;", "\"");
	    }

		private static T FromXml<T>(string xml)
		{
			var returnedXmlClass = default(T);

			try
			{
				using (TextReader reader = new StringReader(xml))
				{
					try
					{
						returnedXmlClass =
							(T)new XmlSerializer(typeof(T)).Deserialize(reader);
					}
					catch (InvalidOperationException)
					{
						// String passed is not XML, simply return defaultXmlClass
					}
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Nao conseguiu converter o xml");
			}

			return returnedXmlClass;
		}

		private static string ChooseUserStory()
		{
			Console.Write("Story: ");
			var workItemRead = Console.ReadLine();
			return workItemRead;
		}
	}
}