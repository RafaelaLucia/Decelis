using decelis_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Interfaces
{
    interface IClassRepository
    {
        List<Class> GetAll();
        Class SearchClass(int idClass);
        void PostClass(Class newClass);
        void DeleteClass(int idClass);
        void UpdateClassId(int idClass, Class classUptodate);
    }
}
