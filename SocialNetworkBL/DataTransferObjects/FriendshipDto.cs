using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class FriendshipDto : DtoBase
    {
        public DateTime FriendshipStart { get; set; }

        public int User1Id { get; set; }

        public int User2Id { get; set; }

        public UserDto User1 { get; set; }

        public UserDto User2 { get; set; }

    }
}
