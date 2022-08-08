using System;
using System.Collections.Generic;

namespace decelis_webAPI.Domains
{
    public partial class TimeClass
    {
        public TimeClass()
        {
            Classes = new HashSet<Class>();
        }

        public short IdTime { get; set; }
        public string PeriodTime { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
