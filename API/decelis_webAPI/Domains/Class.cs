using System;
using System.Collections.Generic;

namespace decelis_webAPI.Domains
{
    public partial class Class
    {
        public Class()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public int IdClass { get; set; }
        public short? IdLevel { get; set; }
        public short? IdTime { get; set; }
        public string NameClass { get; set; }

        public virtual SkillLevel IdLevelNavigation { get; set; }
        public virtual TimeClass IdTimeNavigation { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
