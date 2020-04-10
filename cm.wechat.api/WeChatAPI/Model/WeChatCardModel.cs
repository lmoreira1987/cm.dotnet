using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace WeChatAPI.Model
{
    public class WeChatCardModel
    {
        [JsonProperty("card")]
        public WeChatCard Card { get; set; }
    }

    public class WeChatCard
    {
        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("general_coupon")]
        public WeChatGeneralCoupon GeneralCoupon { get; set; }
    }

    public class WeChatGeneralCoupon
    {
        [JsonProperty("base_info")]
        public WeChatBaseInfo BaseInfo { get; set; }

        [JsonProperty("advanced_info")]
        public WeChatAdvancedInfo AdvancedInfo { get; set; }

        [JsonProperty("default_detail")]
        public string DefaultDetail { get; set; }
    }

    public class WeChatAdvancedInfo
    {
        [JsonProperty("use_condition")]
        public WeChatUseCondition UseCondition { get; set; }

        [JsonProperty("abstract")]
        public WeChatAbstract Abstract { get; set; }

        [JsonProperty("text_image_list")]
        public WeChatTextImageList[] TextImageList { get; set; }

        [JsonProperty("business_service")]
        public string[] BusinessService { get; set; }
    }

    public class WeChatAbstract
    {
        [JsonProperty("abstract")]
        public string Abstract { get; set; }

        [JsonProperty("icon_url_list")]
        public string[] IconUrlList { get; set; }
    }

    public class WeChatTextImageList
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class WeChatUseCondition
    {
        [JsonProperty("can_use_with_other_discount")]
        public bool CanUseWithOtherDiscount { get; set; }
    }

    public class WeChatBaseInfo
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

        [JsonProperty("notice")]
        public string Notice { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date_info")]
        public WeChatDateInfo DateInfo { get; set; }

        [JsonProperty("sku")]
        public WeChatSku Sku { get; set; }

        [JsonProperty("use_limit")]
        public long UseLimit { get; set; }

        [JsonProperty("get_limit")]
        public long GetLimit { get; set; }

        [JsonProperty("use_custom_code")]
        public bool UseCustomCode { get; set; }

        [JsonProperty("get_custom_code_mode")]
        public string GetCustomCodeMode { get; set; }

        [JsonProperty("bind_openid")]
        public bool BindOpenid { get; set; }

        [JsonProperty("can_share")]
        public bool CanShare { get; set; }

        [JsonProperty("can_give_friend")]
        public bool CanGiveFriend { get; set; }

        [JsonProperty("center_title")]
        public string CenterTitle { get; set; }

        [JsonProperty("center_sub_title")]
        public string CenterSubTitle { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("center_app_brand_user_name")]
        public string CenterAppBrandUserName { get; set; }

        [JsonProperty("center_app_brand_pass")]
        public string CenterAppBrandPass { get; set; }
    }

    public class WeChatDateInfo
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("begin_timestamp")]
        public uint BeginTimestamp { get; set; }

        [JsonProperty("end_timestamp")]
        public uint EndTimestamp { get; set; }
    }

    public class WeChatSku
    {
        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }

    //public class WeChatToJsonSerializer
    //{
    //    public static WeChatToJsonSerializer FromJson(string json) => JsonConvert.DeserializeObject<WeChatToJsonSerializer>(json, WeChatToJsonConverter.Settings);
    //}

    //public static class WeChatToJsonSerialize
    //{
    //    public static string ToJson(this WeChatToJsonSerializer self) => JsonConvert.SerializeObject(self, WeChatToJsonConverter.Settings);
    //}

    public static class WeChatConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
        };
    }
}
