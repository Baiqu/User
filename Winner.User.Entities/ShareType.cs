using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.User.Entities
{
    public enum ShareType
    {
        //微信朋友圈
        wechat_timeline = 1,
        //微信好友
        wechat_message = 2,
        //QQ空间
        qq_timeline = 3,
        //QQ好友
        qq_message = 4,
        //微博
        weibo = 5,
        //短信
        sms = 6
    }
}
