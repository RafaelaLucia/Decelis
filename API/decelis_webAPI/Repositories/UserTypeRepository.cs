using decelis_webAPI.Contexts;
using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        DecelisContext ctx = new DecelisContext();
        public void DeleteType(int idType)
        {
            ctx.UserTypes.Remove(SearchType(idType));
            ctx.SaveChanges();
        }

        public List<UserType> GetAll()
        {
            return ctx.UserTypes.ToList();
        }

        public void PostType(UserType newType)
        {
            ctx.UserTypes.Add(newType);
            ctx.SaveChanges();
        }

        public UserType SearchType(int idType)
        {
              return ctx.UserTypes.FirstOrDefault(u => u.IdUserType == idType);
        }

        public void UpdateTypeId(int idType, UserType TypeUptodate)
        {
            UserType typeFetched = ctx.UserTypes.Find(idType);
            if (TypeUptodate.TitleUserType != null)
            {
                typeFetched.TitleUserType = TypeUptodate.TitleUserType;
                ctx.UserTypes.Update(typeFetched);
                ctx.SaveChanges();
            }
        }
    }
}
