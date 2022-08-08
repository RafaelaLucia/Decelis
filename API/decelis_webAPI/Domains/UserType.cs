using System;
using System.Collections.Generic;

namespace decelis_webAPI.Domains
{
    public partial class UserType
    {
        public UserType()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public short IdUserType { get; set; }
        public string TitleUserType { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
