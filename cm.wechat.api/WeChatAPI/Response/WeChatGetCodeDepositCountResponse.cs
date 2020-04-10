using Newtonsoft.Json;

namespace WeChatAPI.Response
{
    public class WeChatGetCodeDepositCountResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
