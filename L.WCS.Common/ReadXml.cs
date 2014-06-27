using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;
using L.WCS.DataModel.Send;
namespace L.WCS.Common
{
    public static class ReadXml
    {
        //把接收到的XML转为字典
        public static Dictionary<string, string> XmlModel(string xmlStr)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlStr);
            Dictionary<string, string> mo = new Dictionary<string, string>();
            var data = doc.DocumentElement.ChildNodes;
            //.SelectNodes("xml");
            for (int i = 0; i < data.Count; i++)
            {
                mo.Add(data.Item(i).LocalName, data.Item(i).InnerText);
            }
            return mo;
        }

        ////从字典中读取指定的值
        public static string ReadModel(string key, Dictionary<string, string> model)
        {
            string str = "";
            model.TryGetValue(key, out str);
            if (str == null)
                str = "";

            return str;
        }
        //输出字符串并结束当前页面进程 MVC必须加return
        public static void ResponseToEnd(string str)
        {
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
            return;
        }

        //输出字符串并结束当前页面进程 MVC必须加return
        public static string Menu()
        {
            string Content = "";
            Content += "欢迎进入【狂野男色俱乐部】/阴险\n\n";

            Content += "不论你是【熊】【狒】【猴】,在这里,在这里,你都会收获爱情的种子.\n";
            Content += "Des一线女星【小倩】带领你,浪,浪,浪出国际舞台.\n";
            Content += "群主【荒山哥哥】,默默支持群活动,冲会员,冲钻石.\n";
            Content += "管理员【疯狂小正泰】,群花一朵,脱衣舞郎.\n\n";

            Content += "开发者：【坏坏】,小单纯,小可爱,没去过酒吧.";
            //Content += "输入以下序号开始获取最新信息：\n";

            //Content += "1,新闻30分\n";
            //Content += "2,电影预告\n";
            //Content += "3,今日说法\n";
            //Content += "4,焦点访谈\n";
            //Content += "5,新闻联播\n";

            //Content += "输入?或帮助 可以显示此菜单";
            return Content;
        }

        public static List<ArticlesModel> Query()
        {
            List<ArticlesModel> listNews = new List<ArticlesModel>();

            ArticlesModel AM1 = new ArticlesModel();
            AM1.Title = "狂野微信公众号开发者:坏坏";
            AM1.Description = "狂野微信公众号开发者";
            AM1.PicUrl = "http://bj.fang100.com.cn/Pic/huaihuai.jpg";
            AM1.Url = "";
            listNews.Add(AM1);

            ArticlesModel AM2 = new ArticlesModel();
            AM2.Title = "狂野群最棒女明星：小倩";
            AM2.Description = "狂野群最棒女明星";
            AM2.PicUrl = "http://bj.fang100.com.cn/Pic/huaihuai.jpg";
            AM2.Url = "";
            listNews.Add(AM2);

            ArticlesModel AM3 = new ArticlesModel();
            AM3.Title = "狂野群最棒女明星：小倩";
            AM3.Description = "狂野群最棒女明星";
            AM3.PicUrl = "http://bj.fang100.com.cn/Pic/huaihuai.jpg";
            AM3.Url = "";
            listNews.Add(AM3);

            return listNews;
        }
    }
}
