using Newtonsoft.Json;

namespace WeChatAPI.Response
{
    public class WeChatImageResponse
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
