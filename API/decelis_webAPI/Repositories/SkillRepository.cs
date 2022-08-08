using decelis_webAPI.Contexts;
using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Repositories
{
    public class SkillRepository : ISkillLevelRepository
    {
        DecelisContext ctx = new DecelisContext();
        public void DeleteSkill(int idLevel)
        {
            ctx.SkillLevels.Remove(SearchSkill(idLevel));
            ctx.SaveChanges();
        }

        public List<SkillLevel> GetAll()
        {
            return ctx.SkillLevels.ToList();
        }

        public void PostSkill(SkillLevel newSkill)
        {
            ctx.SkillLevels.Add(newSkill);
            ctx.SaveChanges();
        }

        public SkillLevel SearchSkill(int idLevel)
        {
            return ctx.SkillLevels.FirstOrDefault(s => s.IdLevel == idLevel);
        }

        public void UpdateSkillId(int idLevel, SkillLevel skillUptodate)
        {
            SkillLevel skillFetched = ctx.SkillLevels.Find(idLevel);
            if (skillUptodate.SkillLevel1 != null)
            {
                skillFetched.SkillLevel1 = skillUptodate.SkillLevel1;
                ctx.SkillLevels.Update(skillFetched);
                ctx.SaveChanges();
            }
        }
    }
}
