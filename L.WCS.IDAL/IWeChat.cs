using L.WCS.DataModel.Send;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.WCS.IDAL
{
    public interface IWeChat
    {
        string SendText(SText model);
        string SendImg(SImg model);
        string SendVoice(SVoice model);
        string SendVideo(SVideo model);
        string SendMusic(Smusic model);
        string SendNews(SNews model);
    }
}
