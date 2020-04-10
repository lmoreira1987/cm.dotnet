using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace CsvZip
{
	class Program
	{
		static void Main(string[] args)
		{
			var fileZip = new FileZip<ObjectToSearialize>();
			var fileCsv = new FileCsv<ObjectToSearialize>();

			var result = ResultData(); // Lista de input
			var grouped = result.OrderBy(x => x.Name)
								.GroupBy(x => x.Name)
								.Select(x => new List<ObjectToSearialize>(x));

			MemoryStream ms = new MemoryStream();

			int count = 0;

			using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
			{

				foreach (var item in grouped)
				{
					string singleCsv, assetName;
					assetName = $"Asset_{count}";

					singleCsv = fileCsv.ReturnStringCsv(count, item);
					fileZip.ZipStream(archive, singleCsv, assetName);

					count++;
				}
			}

			// MD5 Hash
			string md5Hash = fileZip.ResultMd5(ms);


			//var streamZip = GetMonthlyReport(name, datestart, dateend);

			// Servic Zip - get byte[] from ZipFile
			fileZip.StreamWriter(ms, "start1.zip"); // BLOB



			/*
			 Get Todas as Rows para o periodo de data
			 Todas as rows, get das rows por asset
			 Get do CSV por todas as Rows de cada asset
			 Com a lista de CSVs, mandar para zippar

			 */

		}

		

		private static List<ObjectToSearialize> ResultData()
		{
			List<ObjectToSearialize> list = new List<ObjectToSearialize>();
			ObjectToSearialize o = new ObjectToSearialize();
			o.Name = "Asset1";
			o.Name1 = "A";
			o.Name2 = "A";
			o.Name3 = "A";
			list.Add(o);

			o = new ObjectToSearialize();
			o.Name = "Asset1";
			o.Name1 = "A2";
			o.Name2 = "A3";
			o.Name3 = "A4";
			list.Add(o);

			o = new ObjectToSearialize();
			o.Name = "Asset2";
			o.Name1 = "BBB";
			o.Name2 = "CCC";
			o.Name3 = "DDD";
			list.Add(o);

			o = new ObjectToSearialize();
			o.Name = "Asset2";
			o.Name1 = "BBB1";
			o.Name2 = "CCC";
			o.Name3 = "DDD";
			list.Add(o);

			o = new ObjectToSearialize();
			o.Name = "Asset2";
			o.Name1 = "BB2B";
			o.Name2 = "CCC";
			o.Name3 = "DDD";
			list.Add(o);

			o = new ObjectToSearialize();
			o.Name = "Asset3";
			o.Name1 = "BBB";
			o.Name2 = "C3CC";
			o.Name3 = "DDD";
			list.Add(o);
			return list;
		}
	}

	public class ObjectToSearialize
	{
		[Description("Name_desc")]
		public string Name { get; set; }
		[Description("Name1_desc")]
		public string Name1 { get; set; }
		
		public string Name2 { get; set; }
		[Description("Name3_desc")]
		public string Name3 { get; set; }
	}



	//static void CreateCsvZipFileFromListDynamic(string zipName, List<ObjectToSearialize> list)
	//{
	//	string zipPath = @"Files\" + zipName + ".zip"; // Dynamic name

	//	using (var fileStream = new FileStream(zipPath, FileMode.CreateNew))
	//	{
	//		using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
	//		{
	//			var grouped = list.OrderBy(x => x.Name)
	//							.GroupBy(x => x.Name);

	//			foreach (var item in grouped)
	//			{
	//				MemoryStream ms = new CsvSerializer<ObjectToSearialize>().Serialize(item);
	//				var csvBytes = ms.ToArray();
	//				var zipArchiveEntry = archive.CreateEntry(item.FirstOrDefault().Name + "_.csv", CompressionLevel.Optimal);
	//				using (var zipStream = zipArchiveEntry.Open())
	//				{
	//					zipStream.Write(csvBytes, 0, csvBytes.Length);
	//				}
	//			}
	//		}
	//	}
	//}

	//static void CreateCsvZipFileFromList()
	//{
	//	List<ObjectToSearialize> list = new List<ObjectToSearialize>();
	//	ObjectToSearialize o = new ObjectToSearialize();
	//	o.Name = "A";
	//	o.Name1 = "A";
	//	o.Name2 = "A";
	//	o.Name3 = "A";
	//	list.Add(o);

	//	o = new ObjectToSearialize();
	//	o.Name = "A1";
	//	o.Name1 = "A2";
	//	o.Name2 = "A3";
	//	o.Name3 = "A4";
	//	list.Add(o);

	//	o = new ObjectToSearialize();
	//	o.Name = "AAA";
	//	o.Name1 = "BBB";
	//	o.Name2 = "CCC";
	//	o.Name3 = "DDD";
	//	list.Add(o);

	//	string zipPath = @"Files\start.zip"; // Dynamic name

	//	MemoryStream ms = new CsvSerializer<ObjectToSearialize>().Serialize(list);

	//	using (var fileStream = new FileStream(zipPath, FileMode.CreateNew))
	//	{
	//		using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
	//		{
	//			var csvBytes = ms.ToArray();
	//			var zipArchiveEntry = archive.CreateEntry("csvFile.csv", CompressionLevel.Fastest);
	//			using (var zipStream = zipArchiveEntry.Open())
	//			{
	//				zipStream.Write(csvBytes, 0, csvBytes.Length);
	//			}
	//		}
	//	}
	//}

	//static void CreateCsvZipFileFromExistingFiles()
	//{
	//	string zipPath = @"Files\start.zip"; // Dynamic name
	//	var files = Directory.GetFiles("Files");

	//	using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
	//	{
	//		foreach (var item in files)
	//		{
	//			archive.CreateEntryFromFile(item, item.Split("\\")[1], CompressionLevel.Fastest);
	//		}
	//	}
	//}

	//static void CreateCsvZipFile()
	//{
	//	MemoryStream mm = new MemoryStream();
	//	using (var zipArchive = new ZipArchive(mm, ZipArchiveMode.Create, true))
	//	{
	//		var zipEntry = zipArchive.CreateEntry("teste.csv");
	//		using (var entryStream = zipEntry.Open())
	//		{
	//			using (var tmpMemory = new MemoryStream(new byte[mm.Length]))
	//			{
	//				tmpMemory.CopyTo(entryStream);
	//			};

	//		}
	//	}

	//	mm.Seek(0, SeekOrigin.Begin);

	//	using (FileStream file = new FileStream(@"Files\zipFile.zip", FileMode.Create, FileAccess.Write))
	//	{
	//		mm.Seek(0, SeekOrigin.Begin);
	//		mm.CopyTo(file);
	//	}
	//}

}
