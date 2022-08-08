using decelis_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Interfaces
{
    public interface IUserInfoRepository
    {
        List<UserInfo> GetAll();
        UserInfo SearchUser(Guid idUser);
        void PostUser(UserInfo newUser);
        void DeleteUser(Guid idUser);
        void UpdateUserId(Guid idUser, UserInfo UserUptodate);
        UserInfo Login(string email, string password);
    }
}
