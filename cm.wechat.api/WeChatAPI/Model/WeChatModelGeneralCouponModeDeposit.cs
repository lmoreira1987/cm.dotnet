using Newtonsoft.Json;

namespace WeChatAPI.Model
{
    public class WeChatGCMDModel
    {
        [JsonProperty("card")]
        public WeChatGCMDCard Card { get; set; }
    }

    public class WeChatGCMDCard
    {
        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("general_coupon")]
        public WeChatGCMDGeneralCoupon GeneralCoupon { get; set; }
    }

    public class WeChatGCMDGeneralCoupon
    {
        [JsonProperty("base_info")]
        public WeChatGCMDBaseInfo BaseInfo { get; set; }

        [JsonProperty("advanced_info")]
        public WeChatGCMDAdvancedInfo AdvancedInfo { get; set; }

        [JsonProperty("default_detail")]
        public string DefaultDetail { get; set; }
    }

    public class WeChatGCMDAdvancedInfo
    {
        [JsonProperty("business_service")]
        public string[] BusinessService { get; set; }
    }

    public class WeChatGCMDBaseInfo
    {
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("code_type")]
        public string CodeType { get; set; }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date_info")]
        public WeChatGCMDDateInfo DateInfo { get; set; }

        [JsonProperty("sku")]
        public WeChatGCMDSku Sku { get; set; }

        [JsonProperty("get_custom_code_mode")]
        public string GetCustomCodeMode { get; set; }

        [JsonProperty("center_title")]
        public string CenterTitle { get; set; }

        [JsonProperty("center_sub_title")]
        public string CenterSubTitle { get; set; }

        [JsonProperty("center_app_brand_user_name")]
        public string CenterAppBrandUserName { get; set; }

        [JsonProperty("center_app_brand_pass")]
        public string CenterAppBrandPass { get; set; }
    }

    public class WeChatGCMDDateInfo
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("begin_timestamp")]
        public uint BeginTimestamp { get; set; }

        [JsonProperty("end_timestamp")]
        public uint EndTimestamp { get; set; }
    }

    public class WeChatGCMDSku
    {
        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}
