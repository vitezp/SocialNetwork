using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class GroupDto : DtoBase
    {
        public string Name { get; set; }

        public bool AllowAnonymousPosts { get; set; } = false;
    }
}
