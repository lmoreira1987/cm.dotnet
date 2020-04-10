using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WeChatAPI.Factory;
using WeChatAPI.Model;
using WeChatAPI.Response;

namespace WeChatAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeChatController : ControllerBase
    {
        private const string APPID = "APPID";
        private const string APPSECRET = "APPSECRET";

        private const string LOGO_IMAGE_URL = "C:\\WeChat\\WeChatAPI\\WeChatAPI\\Assets\\images\\image.jpg";
        private const string LOGO_IMAGE_FILENAME = "image.jpg";

        private const string PATH_TO_FOLDER = "C:\\WeChat\\WeChatAPI\\WeChatAPI\\Assets\\codes";
        private const string PATH_TO_FOLDER_OLD = "C:\\WeChat\\WeChatAPI\\WeChatAPI\\Assets\\codes\\old";
        private const string PATH_TO_FOLDER_IMPORTED = "C:\\WeChat\\WeChatAPI\\WeChatAPI\\Assets\\codes\\imported";

        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeChatController([FromServices]IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        [HttpPatch]
        [Route("WeChatCreateAndImportCodes")]
        public IActionResult WeChatCreateAndImportCodes()
        {
            WeChatTokenResponse weChatToken = GetWeChatToken(APPID, APPSECRET);
            WeChatImageResponse weChatImage = ReceiveUploadImageRequest(weChatToken);
            WeChatCardResponse weChatCard = ReceiveNewCardRequest(weChatToken, weChatImage);

            var watch = Stopwatch.StartNew();

            ImportCodes(weChatToken, weChatCard);

            watch.Stop();
            string seconds = (watch.ElapsedMilliseconds / 1000).ToString();

            Log(weChatToken, weChatCard, seconds, weChatImage);

            return Ok(weChatCard);
        }

        [HttpPatch]
        [Route("WeChatImportCodes")]
        public IActionResult WeChatImportCodes(string cardId)
        {
            WeChatTokenResponse weChatToken = GetWeChatToken(APPID, APPSECRET);

            WeChatCardResponse weChatCard = new WeChatCardResponse();
            weChatCard.CardId = cardId;

            var watch = Stopwatch.StartNew();
            //VerifyCodes(weChatToken, weChatCard);
            ImportCodes(weChatToken, weChatCard);

            watch.Stop();
            string seconds = (watch.ElapsedMilliseconds / 1000).ToString();

            Log(weChatToken, weChatCard, seconds);

            return Ok(weChatCard);
        }

        private void VerifyCodes(WeChatTokenResponse weChatToken, WeChatCardResponse weChatCard)
        {
            WeChatImportCodesModel weChatImportCodes = WeChatImportCodesFactory.ImportCodes(weChatCard, PATH_TO_FOLDER, PATH_TO_FOLDER_OLD);
            int quantity = 100;

            for (int i = 0; i < weChatImportCodes.Codes.Count; i += quantity)
            {
                var codes = weChatImportCodes.Codes.Skip(i).Take(quantity).ToList();

                WeChatImportCodesResponse importedCodesResponse = new WeChatImportCodesResponse();
                importedCodesResponse.SuccessCodes = new List<string>();
                importedCodesResponse.SuccessCodes.AddRange(codes);

                WeChatImportCodesVerifyingCodeResponse verify = ReceiveVerifyingCodeRequest(weChatToken, weChatCard, importedCodesResponse);

                if (verify.NotExistCodes.Count > 0)
                {
                    Console.WriteLine("duplicated");
                }
            }
        }

        private void ImportCodes(WeChatTokenResponse weChatToken, WeChatCardResponse weChatCard)
        {
            WeChatImportCodesModel weChatImportCodes = WeChatImportCodesFactory.ImportCodes(weChatCard, PATH_TO_FOLDER, PATH_TO_FOLDER_OLD);
            int quantity = 100;
           
            for (int i = 0; i < weChatImportCodes.Codes.Count; i += quantity)
            {
                var codes = weChatImportCodes.Codes.Skip(i).Take(quantity).ToList();

                WeChatImportCodesModel receiveImportCodes = WeChatImportCodesFactory.ReceiveImportCodes(weChatCard, codes);
                WeChatImportCodesResponse importedCodesResponse = ReceiveImportCodeRequest(weChatToken, weChatCard, receiveImportCodes);

                if (importedCodesResponse.SuccessCodes.Count > 0)
                {
                    Console.WriteLine("SuccessCodes Missing");
                }

                if (importedCodesResponse.FailCodes.Count > 0)
                {
                    Console.WriteLine("FailCodes Missing");
                }

                //System.IO.File.WriteAllLines($"{PATH_TO_FOLDER_IMPORTED}\\Imported_From_{i}_{GetFormattedDate()}", importedCodesResponse.SuccessCodes, Encoding.UTF8);

                //ReceiveVerifyingCodeRequest(weChatToken, weChatCard, importedCodesResponse);
                //CallModifyingInventoryIncrease(weChatToken, weChatCard, quantity);
            }

            //ReceiveGetCodeDepositCountRequest(weChatToken, weChatCard);
        }

        /// <summary>
        /// [01] Get Token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        private WeChatTokenResponse GetWeChatToken(string appId, string appSecret)
        {
            try
            {
                string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appId + "&secret=" + appSecret;

                HttpResponseMessage tokenResponse = _httpClient.GetAsync(url).Result;

                var jsonString = tokenResponse.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<WeChatTokenResponse>(jsonString.Result);
            }
            catch (Exception e)
            {
                throw new Exception($"Error on GetWeChatToken.", e);
            }
        }

        /// <summary>
        /// [02] Receive Upload Image Request
        /// </summary>
        /// <param name="weChatToken"></param>
        /// <returns></returns>
        private WeChatImageResponse ReceiveUploadImageRequest(WeChatTokenResponse weChatToken)
        {
            try
            {
                string url = "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token=" + weChatToken.AccessToken;

                FileStream fs = new FileStream(LOGO_IMAGE_URL, FileMode.Open, FileAccess.Read);

                var form = new MultipartFormDataContent();
                form.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                form.Add(new StreamContent(fs), "buffer", "\"" + LOGO_IMAGE_FILENAME + "\"");

                var response = _httpClient.PostAsync(url, form);
                var jsonString = response.Result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<WeChatImageResponse>(jsonString.Result.Replace("\\", ""));
            }
            catch (Exception e)
            {
                throw new Exception($"Error on ReceiveUploadImageRequest.", e);
            }
        }

        /// <summary>
        /// [03] Receive New Card Request
        /// </summary>
        /// <param name="weChatToken"></param>
        /// <param name="weChatImage"></param>
        /// <returns></returns>
        private WeChatCardResponse ReceiveNewCardRequest(WeChatTokenResponse weChatToken, WeChatImageResponse weChatImage)
        {
            try
            {
                string url = "https://api.weixin.qq.com/card/create?access_token=" + weChatToken.AccessToken;

                WeChatCardModel weChatCard = WeChatCardFactory.CreateCard(weChatImage.Url);

                var jsonCard = JsonConvert.SerializeObject(weChatCard, WeChatConverter.Settings);
                var body = new StringContent(jsonCard, Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync(url, body).Result;

                var jsonString = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeChatCardResponse>(jsonString.Result);
            }
            catch (Exception e)
            {
                throw new Exception($"Error on ReceiveNewCardRequest.", e);
            }
        }

        /// <summary>
        /// [06] Receive Import Code Request
        /// </summary>
        /// <param name="weChatToken"></param>
        /// <param name="weChatCard"></param>
        /// <returns></returns>
        private WeChatImportCodesResponse ReceiveImportCodeRequest(WeChatTokenResponse weChatToken, WeChatCardResponse weChatCard, WeChatImportCodesModel weChatImportCodes)
        {
            try
            {
                string url = "http://api.weixin.qq.com/card/code/deposit?access_token=" + weChatToken.AccessToken;

                var jsonImportCodes = JsonConvert.SerializeObject(weChatImportCodes, WeChatConverter.Settings);
                var body = new StringContent(jsonImportCodes, Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync(url, body).Result;

                var jsonString = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeChatImportCodesResponse>(jsonString.Result);
            }
            catch (Exception e)
            {
                throw new Exception($"Error on ReceiveImportCodeRequest.", e);
            }
        }

        /// <summary>
        /// [07] Receive GetCode Deposit Count Request
        /// </summary>
        /// <param name="weChatToken"></param>
        /// <param name="weChatCard"></param>
        /// <returns></returns>
        private WeChatGetCodeDepositCountResponse ReceiveGetCodeDepositCountRequest(WeChatTokenResponse weChatToken, WeChatCardResponse weChatCard)
        {
            try
            {
                string url = "http://api.weixin.qq.com/card/code/getdepositcount?access_token=" + weChatToken.AccessToken;

                var json = "{\"card_id\" : \"" + weChatCard.CardId + "\"}";
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync(url, body).Result;

                var jsonString = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeChatGetCodeDepositCountResponse>(jsonString.Result);
            }
            catch (Exception e)
            {
                throw new Exception($"Error on ReceiveGetCodeDepositCountRequest.", e);
            }
        }

        /// <summary>
        /// [08] Receive Verifying Code Request
        /// </summary>
        /// <param name="weChatToken"></param>
        /// <param name="weChatCard"></param>
        /// <returns></returns>
        private WeChatImportCodesVerifyingCodeResponse ReceiveVerifyingCodeRequest(WeChatTokenResponse weChatToken, WeChatCardResponse weChatCard, WeChatImportCodesResponse importedCodesResponse)
        {
            try
            {
                WeChatImportCodesModel receiveImportCodes = WeChatImportCodesFactory.ReceiveImportCodes(weChatCard, importedCodesResponse.SuccessCodes);

                string url = "http://api.weixin.qq.com/card/code/checkcode?access_token=" + weChatToken.AccessToken;

                var jsonImportCodes = JsonConvert.SerializeObject(receiveImportCodes, WeChatConverter.Settings);
                var body = new StringContent(jsonImportCodes, Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync(url, body).Result;

                var jsonString = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeChatImportCodesVerifyingCodeResponse>(jsonString.Result);
            }
            catch (Exception e)
            {
                throw new Exception($"Error on ReceiveGetCodeDepositCountRequest.", e);
            }
        }

        /// <summary>
        /// [09] Call Modifying Inventory - Increase
        /// </summary>
        /// <param name="weChatToken"></param>
        /// <param name="weChatCard"></param>
        /// <param name="stockQuantity"></param>
        /// <returns></returns>
        private WeChatModifyingInventoryIncreaseResponse CallModifyingInventoryIncrease(WeChatTokenResponse weChatToken, WeChatCardResponse weChatCard, int quantity)
        {
            try
            {
                string url = "https://api.weixin.qq.com/card/modifystock?access_token=" + weChatToken.AccessToken;

                var json = "{\"card_id\" : \"" + weChatCard.CardId + "\", \"increase_stock_value\": " + quantity + "}";
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync(url, body).Result;

                var jsonString = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeChatModifyingInventoryIncreaseResponse>(jsonString.Result);
            }
            catch (Exception e)
            {
                throw new Exception($"Error on CallModifyingInventoryIncrease.", e);
            }
        }

        private void Log(WeChatTokenResponse weChatToken, WeChatCardResponse weChatCard, string time, WeChatImageResponse weChatImage = null)
        {
            try
            {
                string log = weChatToken != null ? $"TOKEN: {weChatToken.AccessToken}\n" : "";
                log += weChatCard != null ? $"CardId: {weChatCard.CardId}\n" : "";
                log += !string.IsNullOrEmpty(time) ? $"Time: {time}\n" : "";
                log += weChatImage != null ? $"LogoUrl: {weChatImage.Url}\n" : "";

                System.IO.File.WriteAllText($"Temp//Card_{GetFormattedDate()}.txt", log);
            }
            catch (Exception e)
            {
                throw new Exception($"Error on Log.", e);
            }
        }

        private string GetFormattedDate()
        {
            return $"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_-_{DateTime.Now.Hour}_{DateTime.Now.Minute}";
        }
    }
}
