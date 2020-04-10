using WeChatAPI.Model;

namespace WeChatAPI.Factory
{
    public static class WeChatCardFactory
    {
        public static WeChatCardModel CreateCard(string logoUrl, string mode = "GET_CUSTOM_CODE_MODE_DEPOSIT", long skuQuantity = 0)
        {
            WeChatCardModel weChatCard = new WeChatCardModel();

            // Card
            weChatCard.Card = new WeChatCard();
            weChatCard.Card.CardType = "GENERAL_COUPON";
            
            // General Coupon
            weChatCard.Card.GeneralCoupon = new WeChatGeneralCoupon();

            // Base Info
            weChatCard.Card.GeneralCoupon.BaseInfo = new WeChatBaseInfo();
            weChatCard.Card.GeneralCoupon.BaseInfo.LogoUrl = logoUrl;
            //weChatCard.Card.GeneralCoupon.BaseInfo.LogoUrl = "http://mmbiz.qpic.cn/mmbiz_jpg/FAg9ej2DnNoSg7890kn3p3iaibzrKG1USzPAfZkLF76pNuS4iaR9hMXpcX1CfyJCrF4cyOUCPibWZc7A6Y8S6fFWxg/0"; //weChat.LogoUrl;
            weChatCard.Card.GeneralCoupon.BaseInfo.BrandName = "伦敦比斯特购物村";
            weChatCard.Card.GeneralCoupon.BaseInfo.CodeType = "CODE_TYPE_QRCODE";
            weChatCard.Card.GeneralCoupon.BaseInfo.Title = "9折VIP优惠券↗↗↗";
            weChatCard.Card.GeneralCoupon.BaseInfo.Color = "Color010";
            weChatCard.Card.GeneralCoupon.BaseInfo.Description = "本页面是专属于您的VIP贵宾卡，结账时出示本页二维码可在参与活动的精品店及餐厅享受额外九折*优惠，首次使用后24小时内有效。";

            // Base info - Date Info
            weChatCard.Card.GeneralCoupon.BaseInfo.DateInfo = new WeChatDateInfo();
            weChatCard.Card.GeneralCoupon.BaseInfo.DateInfo.Type = "DATE_TYPE_FIX_TIME_RANGE";
            weChatCard.Card.GeneralCoupon.BaseInfo.DateInfo.BeginTimestamp = 1583936936;
            weChatCard.Card.GeneralCoupon.BaseInfo.DateInfo.EndTimestamp = 1609430399;

            // Base info - Sku
            weChatCard.Card.GeneralCoupon.BaseInfo.Sku = new WeChatSku();
            weChatCard.Card.GeneralCoupon.BaseInfo.Sku.Quantity = skuQuantity;

            // Base info
            weChatCard.Card.GeneralCoupon.BaseInfo.UseLimit = 1;
            weChatCard.Card.GeneralCoupon.BaseInfo.GetLimit = 1;
            weChatCard.Card.GeneralCoupon.BaseInfo.UseCustomCode = true;
            weChatCard.Card.GeneralCoupon.BaseInfo.GetCustomCodeMode = mode;
            weChatCard.Card.GeneralCoupon.BaseInfo.BindOpenid = false;
            weChatCard.Card.GeneralCoupon.BaseInfo.CanShare = false;
            weChatCard.Card.GeneralCoupon.BaseInfo.CanGiveFriend = false;
            weChatCard.Card.GeneralCoupon.BaseInfo.CenterTitle = "购物村精选餐饮一览";
            weChatCard.Card.GeneralCoupon.BaseInfo.CenterSubTitle = "点击右上角获取折扣二维码";
            weChatCard.Card.GeneralCoupon.BaseInfo.CenterAppBrandUserName = "gh_de4dfd63cec7@app";
            weChatCard.Card.GeneralCoupon.BaseInfo.CenterAppBrandPass = "pages/hotel/hotel?hotelId=2";

            // Advanced Info
            weChatCard.Card.GeneralCoupon.AdvancedInfo = new WeChatAdvancedInfo();
            weChatCard.Card.GeneralCoupon.AdvancedInfo.UseCondition = new WeChatUseCondition();
            weChatCard.Card.GeneralCoupon.AdvancedInfo.UseCondition.CanUseWithOtherDiscount = false;

            // Advanced Info - Abstract
            weChatCard.Card.GeneralCoupon.AdvancedInfo.Abstract = new WeChatAbstract();
            weChatCard.Card.GeneralCoupon.AdvancedInfo.Abstract.Abstract = "伦敦比斯特购物村";
            weChatCard.Card.GeneralCoupon.AdvancedInfo.Abstract.IconUrlList = new string[] { "http://mmbiz.qpic.cn/mmbiz_jpg/FAg9ej2DnNoSg7890kn3p3iaibzrKG1USzjAD8naiagf8LBjBibAo1o5gX8OrKCzVl8yY0HhxPibiaA6Mu4a9T4HQTpQ/0" };

            // Advanced Info - TextImageList
            weChatCard.Card.GeneralCoupon.AdvancedInfo.TextImageList = new WeChatTextImageList[] {
                new WeChatTextImageList() {
                    ImageUrl = "http://mmbiz.qpic.cn/mmbiz_jpg/FAg9ej2DnNoSg7890kn3p3iaibzrKG1USzLiaSLqG9aCKVg07oZVLFcEJtM81cpuNgO3FsCibZ3OAGGwplrvKrTcVQ/0",
                    Text = "伦敦比斯特购物村优惠券"
                }
            };

            // Advanced Info - BusinessService
            weChatCard.Card.GeneralCoupon.AdvancedInfo.BusinessService = new string[] {
                "BIZ_SERVICE_FREE_WIFI",
                "BIZ_SERVICE_WITH_PET",
                "BIZ_SERVICE_FREE_PARK"
            };

            weChatCard.Card.GeneralCoupon.DefaultDetail = "本页面是专属于您的VIP贵宾卡，可在参与活动的精品店及餐厅享受额外九折*优惠。";

            return weChatCard;
        }
    }
}
