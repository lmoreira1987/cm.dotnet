using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WeChatAPI.Model;
using WeChatAPI.Response;

namespace WeChatAPI.Factory
{
    public static class WeChatImportCodesFactory
    {
        public static WeChatImportCodesModel ImportCodes(WeChatCardResponse weChatCard, string pathToFolder, string pathToFolderOld)
        {
            WeChatImportCodesModel weChatImportCodes = new WeChatImportCodesModel();

            weChatImportCodes.CardId = weChatCard.CardId;
            weChatImportCodes.Codes = new List<string>();

            string[] files = Directory.GetFiles(pathToFolder, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                using StreamReader sr = new StreamReader(file);
                string content = sr.ReadToEnd();
                var codes = content.Replace(Environment.NewLine, ",").Replace("\"", "").Split(',').
                          Select(tag => tag.Trim()).
                          Where(tag => !string.IsNullOrEmpty(tag)).ToList();

                weChatImportCodes.Codes.AddRange(codes);

                string date = $"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_-_{DateTime.Now.Hour}_{DateTime.Now.Minute}";
                File.Copy(file, $"{pathToFolderOld}/Old_{date}_{Path.GetFileName(file)}", false);
            }

            foreach (string file in files)
            {
                File.Delete(file);
            }

            return weChatImportCodes;
        }

        public static WeChatImportCodesModel ReceiveImportCodes(WeChatCardResponse weChatCard, List<string> codes)
        {
            WeChatImportCodesModel weChatImportCodes = new WeChatImportCodesModel();

            weChatImportCodes.CardId = weChatCard.CardId;
            weChatImportCodes.Codes = new List<string>();
            weChatImportCodes.Codes.AddRange(codes);

            return weChatImportCodes;
        }
    }
}
