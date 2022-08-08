using decelis_webAPI.Contexts;
using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class = decelis_webAPI.Domains.Class;


namespace decelis_webAPI.Repositories
{
    public class ClassRepository : IClassRepository
    {
        DecelisContext ctx = new DecelisContext();
        public void DeleteClass(int idClass)
        {
            ctx.Classes.Remove(SearchClass(idClass));
            ctx.SaveChanges();
        }

        public List<Class> GetAll()
        {
            return ctx.Classes.ToList();
        }

        public void PostClass(Class newClass)
        {
            ctx.Classes.Add(newClass);
            ctx.SaveChanges();
        }

        public Class SearchClass(int idClass)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClass == idClass);
        }

        public void UpdateClassId(int idClass, Class classUptodate)
        {
            Class classFetched = ctx.Classes.Find(idClass);
            if(classUptodate.NameClass != null)
            {
                classFetched.IdLevel = classUptodate.IdLevel;
                classFetched.IdTime = classUptodate.IdTime;
                classFetched.NameClass = classUptodate.NameClass;
                ctx.Classes.Update(classFetched);
                ctx.SaveChanges();
            }
        }
    }
}
