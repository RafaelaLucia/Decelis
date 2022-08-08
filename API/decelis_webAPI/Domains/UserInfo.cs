using System;
using System.Collections.Generic;

namespace decelis_webAPI.Domains
{
    public partial class UserInfo
    {
        public Guid IdUser { get; set; }
        public short? IdUserType { get; set; }
        public short? IdStatus { get; set; }
        public int? IdClass { get; set; }
        public string NameUser { get; set; }
        public string Email { get; set; }
        public string PasswordUser { get; set; }
        public string UserImage { get; set; }

        public virtual Class IdClassNavigation { get; set; }
        public virtual StatusType IdStatusNavigation { get; set; }
        public virtual UserType IdUserTypeNavigation { get; set; }
    }
}
