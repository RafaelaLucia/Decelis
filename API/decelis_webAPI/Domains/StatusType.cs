using System;
using System.Collections.Generic;

namespace decelis_webAPI.Domains
{
    public partial class StatusType
    {
        public StatusType()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public short IdStatus { get; set; }
        public bool ActiveStatus { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
