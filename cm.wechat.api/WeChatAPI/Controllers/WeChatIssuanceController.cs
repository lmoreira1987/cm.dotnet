using System;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using static Tencent.WXBizMsgCrypt;

namespace WeChatAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeChatIssuanceController : ControllerBase
    {
        //private TelemetryClient _telemetryClient;
        private string TOKEN = "vRtOkEnTeSt";

        //public WeChatController(TelemetryClient telemetryClient)
        //{

        //    //_telemetryClient = telemetryClient;

        //    ///telemetryClient.TrackRequest(new RequestTelemetry());
        //}

        [HttpGet]
        [Route("WeChatHandler")]
        public string WeChatHandler(string signature, string timestamp, string nonce, string echostr)
        {
            // Log App Insight
            System.IO.File.WriteAllText($"GETWriteLines_{DateTime.Now.Ticks}.txt", $"GET: signature: {signature} *** timestamp: {timestamp} *** nonce: {nonce} *** echostr: {echostr}" + Environment.NewLine);
            //_telemetryClient.TrackTrace($"GET: signature: {signature} *** timestamp: {timestamp} *** nonce: {nonce} *** echostr: {echostr}");

            string tmpStr = string.Empty;
            int ret = GenarateSinature(this.TOKEN, timestamp, nonce, string.Empty, ref tmpStr);
            if (ret != 0)
            {
                //_telemetryClient.TrackException(new Exception($"GET: Computed Signature Error -> signature: {signature} *** timestamp: {timestamp} *** nonce: {nonce} *** echostr: {echostr}"));
                throw new Exception($"GET: Computed Signature Error -> signature: {signature} *** timestamp: {timestamp} *** nonce: {nonce} *** echostr: {echostr}");
            }
            else if (tmpStr == signature)
                return echostr;
            else
            {
                // _telemetryClient.TrackException(new Exception($"GET: The request is not comming from WeChat -> signature: {signature} *** timestamp: {timestamp} *** nonce: {nonce} *** echostr: {echostr}"));
                throw new Exception($"GET: The request is not comming from WeChat -> signature: {signature} *** timestamp: {timestamp} *** nonce: {nonce} *** echostr: {echostr}");
            }
        }

        [HttpPost]
        [Route("WeChatHandler")]
        public string WeChatHandler([FromBody]XmlElement response, [FromQuery]string signature, [FromQuery]string nonce, [FromQuery]string timestamp, [FromQuery]string openid)
        {
            System.IO.File.WriteAllText($"POSTWriteLines_{DateTime.Now.Ticks}.txt", response.InnerXml + Environment.NewLine + signature + Environment.NewLine + nonce + Environment.NewLine + timestamp + Environment.NewLine + openid);
            //this._telemetryClient.TrackTrace($"POST: {r.InnerXml}");
            //return request.InnerXml;

            return response.InnerXml;
        }

    }
}