using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeChatAPI.Model
{
    public class WeChatImportCodesModel
    {
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        [JsonProperty("code")]
        public List<string> Codes { get; set; }
    }
}
