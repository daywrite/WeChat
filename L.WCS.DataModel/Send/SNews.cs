using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.WCS.DataModel.Send
{
    public class SNews
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 用户号（OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 图文个数
        /// </summary>
        public int ArticleCount { get; set; }

        /// <summary>
        /// 图文列表
        /// </summary>
        public List<ArticlesModel> Articles { get; set; }
    }

    /// <summary>
    /// 默认第一条大图显示
    /// </summary>
    public class ArticlesModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片链接 
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 点击之后跳转的链接
        /// </summary>
        public string Url { get; set; }
    }
}
