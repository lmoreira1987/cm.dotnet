using Newtonsoft.Json;

namespace WeChatAPI.Response
{
    public class WeChatModifyingInventoryIncreaseResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
    }
}
