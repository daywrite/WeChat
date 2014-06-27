using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.WCS.DataModel.Send
{
    public class Smusic
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
        /// 音乐标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 音乐描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 音乐链接
        /// </summary>
        public string MusicURL { get; set; }

        /// <summary>
        /// 高音质链接
        /// </summary>
        public string HQMusicUrl { get; set; }

        /// <summary>
        /// 上传的缩略图ID
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
}
