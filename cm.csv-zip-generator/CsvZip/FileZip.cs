using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CsvZip
{
	public class FileZip<T> where T : new()
	{
		public void StreamWriter(Stream s, string zipName)
		{
			using (FileStream file = new FileStream(zipName, FileMode.Create, FileAccess.Write))
			{
				s.Seek(0, SeekOrigin.Begin);
				s.CopyTo(file);
			}
		}

		public void ZipStream(ZipArchive archive, string singleCsv, string assetName)
		{
			MemoryStream singleCsvStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(singleCsv));

			var csvBytes = singleCsvStream.ToArray();

			var zipArchiveEntry = archive.CreateEntry(assetName + "_.csv", CompressionLevel.Optimal);

			using (var zipStream = zipArchiveEntry.Open())
			{
				zipStream.Write(csvBytes, 0, csvBytes.Length);
			}
		}

		public string ResultMd5(MemoryStream ms)
		{
			string resultMd5 = String.Empty;
			using (var md5 = MD5.Create())
			{
				var hash = md5.ComputeHash(ms);
				resultMd5 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
			}

			return resultMd5;
		}
	}
}
