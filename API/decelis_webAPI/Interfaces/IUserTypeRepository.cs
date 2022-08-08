using decelis_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Interfaces
{
    public interface IUserTypeRepository
    {
        List<UserType> GetAll();
        UserType SearchType(int idType);
        void PostType(UserType newType);
        void DeleteType(int idType);
        void UpdateTypeId(int idType, UserType TypeUptodate);
    }
}
