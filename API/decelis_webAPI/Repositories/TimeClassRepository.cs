using decelis_webAPI.Contexts;
using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Repositories
{
    public class TimeClassRepository : ITimeClassRepository
    {
        DecelisContext ctx = new DecelisContext();
        public void DeleteTime(int idTime)
        {
            ctx.TimeClasses.Remove(SearchTime(idTime));
            ctx.SaveChanges();
        }

        public List<TimeClass> GetAll()
        {
            return ctx.TimeClasses.ToList();
        }

        public void PostTime(TimeClass newTime)
        {
            ctx.TimeClasses.Add(newTime);
            ctx.SaveChanges();
        }

        public TimeClass SearchTime(int idTime)
        {
            return ctx.TimeClasses.FirstOrDefault(t => t.IdTime == idTime);
        }

        public void UpdateTimeId(int idTime, TimeClass timeUptodate)
        {
            TimeClass timeFetched = ctx.TimeClasses.Find(idTime);
            if (timeUptodate.PeriodTime != null)
            {
                timeFetched.PeriodTime = timeUptodate.PeriodTime;
                ctx.TimeClasses.Update(timeFetched);
                ctx.SaveChanges();
            }
        }
    }
}
