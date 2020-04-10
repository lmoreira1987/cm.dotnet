using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeChatAPI.Response
{
    public class WeChatImportCodesResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("card_id")]
        public string CardId { get; set; }

        [JsonProperty("succ_code")]
        public List<string> SuccessCodes { get; set; }

        [JsonProperty("duplicate_code")]
        public List<string> DuplicatedCodes { get; set; }

        [JsonProperty("fail_code")]
        public List<string> FailCodes { get; set; }
    }
}
