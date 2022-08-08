using decelis_webAPI.Contexts;
using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Repositories
{
    public class StatusTypeRepository : IStatusTypeRepository
    {
        DecelisContext ctx = new DecelisContext();
        public void DeleteStatus(int idStatus)
        {
            ctx.StatusTypes.Remove(SearchStatus(idStatus));
            ctx.SaveChanges();
            //teste
        }

        public List<StatusType> GetAll()
        {
            return ctx.StatusTypes.ToList();
        }

        public void PostStatus(StatusType newStatus)
        {
            ctx.StatusTypes.Add(newStatus);
            ctx.SaveChanges();
        }

        public StatusType SearchStatus(int idStatus)
        {
            return ctx.StatusTypes.FirstOrDefault(s => s.IdStatus == idStatus);
        }

    }
}
