using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Interfaces
{
    interface IPostable
    {
        int Id { get; set; }
        DateTime PostedAt { get; set; }
        string Text { get; set; }

        //post as an anonymous ? true : false
        bool StayAnonymous { get; set; }
    }
}
