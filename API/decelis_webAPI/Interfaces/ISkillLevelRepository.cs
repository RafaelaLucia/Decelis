using decelis_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Interfaces
{
    public interface ISkillLevelRepository
    {
        List<SkillLevel> GetAll();
        SkillLevel SearchSkill(int idLevel);
        void PostSkill(SkillLevel newSkill);
        void DeleteSkill(int idLevel);
        void UpdateSkillId(int idLevel, SkillLevel skillUptodate);
    }
}
