using System;
using System.Collections.Generic;

namespace decelis_webAPI.Domains
{
    public partial class SkillLevel
    {
        public SkillLevel()
        {
            Classes = new HashSet<Class>();
        }

        public short IdLevel { get; set; }
        public string SkillLevel1 { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
