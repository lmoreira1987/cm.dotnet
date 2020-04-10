using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeChatAPI.Response
{
    public class WeChatImportCodesVerifyingCodeResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("exist_code")]
        public List<string> ExistCodes { get; set; }

        [JsonProperty("not_exist_code")]
        public List<string> NotExistCodes { get; set; }
    }
}
