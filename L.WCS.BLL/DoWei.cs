using L.WCS.Common;
using L.WCS.DataModel.Send;
using L.WCS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.WCS.BLL
{
    public class DoWei : IDoWei
    {
        public IDAL.IWeChat DALWei = new DAL.WeChat();

        /// <summary>
        /// 接收到文本消息、处理
        /// lwb 2014-6-27
        /// </summary>
        /// <param name="model">固定文本消息</param>
        public void DoText(Dictionary<string, string> model)
        {
            SText mT = new SText();

            string text = ReadXml.ReadModel("Content", model).Trim();
            mT.FromUserName = ReadXml.ReadModel("ToUserName", model);
            mT.ToUserName = ReadXml.ReadModel("FromUserName", model);
            mT.CreateTime = long.Parse(ReadXml.ReadModel("CreateTime", model));

            if (text == "?" || text == "？" || text == "帮助")
            {
                mT.Content = mT.Content = ReadXml.Menu();
                mT.MsgType = "text";
                ReadXml.ResponseToEnd(DALWei.SendText(mT));
            }
            else
            {
                SNews mN = new SNews();
                mN.FromUserName = ReadXml.ReadModel("ToUserName", model);
                mN.ToUserName = ReadXml.ReadModel("FromUserName", model);
                mN.CreateTime = long.Parse(ReadXml.ReadModel("CreateTime", model));
                mN.MsgType = "news";

                mN.ArticleCount = 3;
                //List<ArticlesModel> listNews = new List<ArticlesModel>();
                //for (int i = 0; i < 5; i++)
                //{
                //    ArticlesModel ma = new ArticlesModel();
                //    ma.Title = "这是第" + (i + 1).ToString() + "篇文章";
                //    ma.Description = "-描述-" + i.ToString() + "-描述-";
                //    ma.PicUrl = "http://image6.tuku.cn/pic/wallpaper/dongwu/taipingniaogaoqingbizhi/s00" + (i + 1).ToString() + ".jpg";
                //    ma.Url = "http://www.cnblogs.com/mochen/";
                //    listNews.Add(ma);
                //}
                mN.Articles = ReadXml.Query();
                ReadXml.ResponseToEnd(DALWei.SendNews(mN));
            }
        }

        public void DoImg(Dictionary<string, string> model)
        {
            throw new NotImplementedException();
        }

        public void DoVoice(Dictionary<string, string> model)
        {
            throw new NotImplementedException();
        }

        public void DoVideo(Dictionary<string, string> model)
        {
            throw new NotImplementedException();
        }

        public void DoLocation(Dictionary<string, string> model)
        {
            throw new NotImplementedException();
        }

        public void DoLink(Dictionary<string, string> Model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 普通关注
        /// lwb 2014-6-27
        /// </summary>
        /// <param name="model"></param>
        public void DoOn(Dictionary<string, string> model)
        {
            SText mT = new SText();
            mT.Content = ReadXml.Menu();
            mT.FromUserName = ReadXml.ReadModel("ToUserName", model);
            mT.ToUserName = ReadXml.ReadModel("FromUserName", model);
            mT.MsgType = "text";
            mT.CreateTime = long.Parse(ReadXml.ReadModel("CreateTime", model));
            ReadXml.ResponseToEnd(DALWei.SendText(mT));
        }

        public void DoUnOn(Dictionary<string, string> Model)
        {
            throw new NotImplementedException();
        }

        public void DoOnCode(Dictionary<string, string> model)
        {
            SText mT = new SText();
            mT.Content = ReadXml.Menu();
            mT.FromUserName = ReadXml.ReadModel("ToUserName", model);
            mT.ToUserName = ReadXml.ReadModel("FromUserName", model);
            mT.MsgType = "text";
            mT.CreateTime = long.Parse(ReadXml.ReadModel("CreateTime", model));
            ReadXml.ResponseToEnd(DALWei.SendText(mT));
        }

        public void DoSubCode(Dictionary<string, string> model)
        {
            SText mT = new SText();
            mT.Content = ReadXml.Menu();
            mT.FromUserName = ReadXml.ReadModel("ToUserName", model);
            mT.ToUserName = ReadXml.ReadModel("FromUserName", model);
            mT.MsgType = "text";
            mT.CreateTime = long.Parse(ReadXml.ReadModel("CreateTime", model));
            ReadXml.ResponseToEnd(DALWei.SendText(mT));
        }

        public void DoSubLocation(Dictionary<string, string> Model)
        {
            throw new NotImplementedException();
        }

        public void DoSubClick(Dictionary<string, string> Model)
        {
            throw new NotImplementedException();
        }

        public void DoSubView(Dictionary<string, string> Model)
        {
            throw new NotImplementedException();
        }
    }
}
