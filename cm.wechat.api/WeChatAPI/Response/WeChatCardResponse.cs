using Newtonsoft.Json;

namespace WeChatAPI.Response
{
    public class WeChatCardResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("card_id")]
        public string CardId { get; set; }
    }
}
