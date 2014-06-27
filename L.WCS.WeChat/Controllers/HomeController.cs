
using L.WCS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace L.WCS.WeChat.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 操作类用到的实例
        /// </summary>
        IBLL.IDoWei BLLWei = new BLL.DoWei();

        /// <summary>
        /// 微信接口请求地址入口
        /// </summary>
        public void Index()
        {
            //用来接受传递过来的XML字符串
            string xmlData = string.Empty;

            //将传递过来的字符串转换成Dictionary<string,string>
            Dictionary<string, string> Model = new Dictionary<string, string>();

            //"POST"方法
            if (Request.HttpMethod.ToUpper() == "POST")
            {
                //获取网络传输的字节流
                using (Stream stream = Request.InputStream)
                {
                    Byte[] byteData = new Byte[stream.Length];
                    stream.Read(byteData, 0, (Int32)stream.Length);
                    xmlData = Encoding.UTF8.GetString(byteData);
                }
                //!string.IsNullOrEmpty(xmlData)判断是否为空
                if ((xmlData + "").Length > 0)
                {
                    try
                    {
                        //将字符串转换成Dictionary<string,string>
                        Model = ReadXml.XmlModel(xmlData);
                    }
                    catch
                    {
                        //未能正确处理 给微信服务器回复默认值
                        DefaultResult();
                    }
                }
                //是否有数据
                if (Model.Count > 0)
                {
                    string msgType = ReadXml.ReadModel("MsgType", Model);

                    #region 判断消息类型

                    switch (msgType)
                    {
                        //文本消息
                        case "text":
                            BLLWei.DoText(Model);
                            break;
                        //图片
                        case "image":
                            BLLWei.DoImg(Model);
                            break;
                        //声音
                        case "voice":
                            BLLWei.DoVoice(Model);
                            break;
                        //视频
                        case "video":
                            BLLWei.DoVideo(Model);
                            break;
                        //地理位置
                        case "location":
                            BLLWei.DoLocation(Model);
                            break;
                        //链接
                        case "link":
                            BLLWei.DoLink(Model);
                            break;
                        //事件
                        case "event":
                            switch (ReadXml.ReadModel("Event", Model))
                            {
                                case "subscribe":
                                    if (ReadXml.ReadModel("EventKey", Model).IndexOf("qrscene_") >= 0)
                                    {
                                        //带参数的二维码扫描关注
                                        BLLWei.DoOnCode(Model);
                                    }
                                    else
                                    {
                                        //普通关注
                                        BLLWei.DoOn(Model);
                                    }
                                    break;
                                //取消关注
                                case "unsubscribe":
                                    BLLWei.DoUnOn(Model);
                                    break;
                                //已经关注的用户扫描带参数的二维码
                                case "SCAN":
                                    BLLWei.DoSubCode(Model);
                                    break;
                                //用户上报地理位置
                                case "LOCATION":
                                    BLLWei.DoSubLocation(Model);
                                    break;
                                //自定义菜单点击
                                case "CLICK":
                                    BLLWei.DoSubClick(Model);
                                    break;
                                //自定义菜单跳转事件
                                case "VIEW":
                                    BLLWei.DoSubView(Model);
                                    break;
                            };
                            break;
                    }
                    #endregion
                }
            }
            else
            {
                //get
                string echostr = Request.QueryString["echostr"];
                //这里直接返回echostr参数接入成功;
                ReadXml.ResponseToEnd(echostr);

            }
        }

        //返回默认值
        public void DefaultResult()
        {
            ReadXml.ResponseToEnd("");

        }

        #region 验证Token

        private static readonly string Token = "daywrite";

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    string echoStr = Request.QueryString["echostr"];
        //    if (CheckSignature())
        //    {
        //        if (!string.IsNullOrEmpty(echoStr))
        //        {
        //            return Content(echoStr);
        //        }
        //    }
        //    return null;
        //}

        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// * 将token、timestamp、nonce三个参数进行字典序排序
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        /// <returns></returns>
        private bool CheckSignature()
        {
            string signature = Request.QueryString["signature"];
            string timestamp = Request.QueryString["timestamp"];
            string nonce = Request.QueryString["nonce"];
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Valid()
        {
            string echoStr = Request.QueryString["echoStr"];
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    Response.Write(echoStr);
                    Response.End();
                }
            }
        }

        #endregion
    }
}
