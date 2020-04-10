using Newtonsoft.Json;

namespace WeChatAPI.Response
{
    public class WeChatTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
    }
}
