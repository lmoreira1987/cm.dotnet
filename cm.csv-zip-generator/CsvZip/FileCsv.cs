using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CsvZip
{
	public class FileCsv<T> where T : new()
	{
		public char Separator { get { return ','; } }

		public string Replacement { get; set; }

		private List<PropertyInfo> _properties;

		public FileCsv()
		{
			var type = typeof(T);

			var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance
				 | BindingFlags.GetProperty | BindingFlags.SetProperty);

			_properties = (from a in properties
						   orderby a.Name
						   select a).ToList();
		}

		private string GetHeader()
		{
			var columns = GetAttributesName();

			var header = string.Join(Separator.ToString(), columns);
			return header;
		}

		public string[] GetAttributesName()
		{
			var type = typeof(T);
			var propertyMetaData = type
				.GetProperties()
				.Select(property => ((DescriptionAttribute)property.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault()) == null ? 
										property.Name : 
										((DescriptionAttribute)property.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault())
											.Description)
				.ToArray();

			return propertyMetaData;
		}

		public string ReturnStringCsv(int count, List<ObjectToSearialize> item)
		{
			return new FileCsv<ObjectToSearialize>().Serialize(item);
		}

		public string Serialize(dynamic data)
		{
			var sb = new StringBuilder();
			var values = new List<string>();

			sb.AppendLine(GetHeader());

			foreach (var item in data)
			{
				values.Clear();

				foreach (var p in _properties)
				{
					var raw = p.GetValue(item);
					var value = raw == null ?
								"" :
								raw.ToString().Replace(Separator.ToString(), Replacement);
					values.Add(value);
				}
				sb.AppendLine(string.Join(Separator.ToString(), values.ToArray()));
			}

			return sb.ToString().Trim();
		}

		public List<T> Deserialize(Stream stream)
		{
			string[] columns;
			string[] rows;

			try
			{
				using (var sr = new StreamReader(stream))
				{
					columns = sr.ReadLine().Split(Separator);
					rows = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(
						"The CSV File is Invalid. See Inner Exception for more inoformation.", ex);
			}

			var data = new List<T>();
			for (int row = 0; row < rows.Length; row++)
			{
				var line = rows[row];
				if (string.IsNullOrWhiteSpace(line))
				{
					throw new Exception(string.Format(
							@"Error: Empty line at line number: {0}", row));
				}

				var parts = line.Split(Separator);

				T datum = new T();
				for (int i = 0; i < parts.Length; i++)
				{
					var value = parts[i];
					var column = columns[i];

					value = value.Replace(Replacement, Separator.ToString());

					var p = _properties.First(a => a.Name == column);

					var converter = TypeDescriptor.GetConverter(p.PropertyType);
					var convertedvalue = converter.ConvertFrom(value);

					p.SetValue(datum, convertedvalue);
				}
				data.Add(datum);
			}
			return data;
		}
	}
}
