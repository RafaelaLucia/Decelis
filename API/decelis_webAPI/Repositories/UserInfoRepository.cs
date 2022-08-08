using decelis_webAPI.Contexts;
using decelis_webAPI.Domains;
using decelis_webAPI.Interfaces;
using decelis_webAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decelis_webAPI.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        DecelisContext ctx = new DecelisContext();
        public void DeleteUser(Guid idUser)
        {
            ctx.UserInfos.Remove(SearchUser(idUser));
            ctx.SaveChanges();
        }

        public List<UserInfo> GetAll()
        {
            return ctx.UserInfos.Include(c => c.IdClassNavigation).ToList();
        }

        public UserInfo Login(string email, string password)
        {
            var usuario = ctx.UserInfos.FirstOrDefault(u => u.Email == email);

            if (usuario.PasswordUser[0] != '$')
            {
                usuario.PasswordUser = Cryptography.CreateHash(usuario.PasswordUser);
                ctx.SaveChanges();
            }

            if (usuario != null)
            {
                bool check = Cryptography.Compare(password, usuario.PasswordUser);
                if (check) return usuario;
            }

            return null;
        }

        public void PostUser(UserInfo newUser)
        {
            ctx.UserInfos.Add(newUser);
            ctx.SaveChanges();
        }

        public UserInfo SearchUser(Guid idUser)
        {
            return ctx.UserInfos.FirstOrDefault(u => u.IdUser == idUser);
        }

        public void UpdateUserId(Guid idUser, UserInfo UserUptodate)
        {
            UserInfo userFetched = ctx.UserInfos.Find(idUser);
            if (UserUptodate.NameUser != null)
            {
                userFetched.IdUserType = UserUptodate.IdUserType;
                userFetched.IdStatus = UserUptodate.IdStatus;
                userFetched.IdClass = UserUptodate.IdClass;
                userFetched.NameUser = UserUptodate.NameUser;
                userFetched.Email = UserUptodate.Email;
                userFetched.PasswordUser = UserUptodate.PasswordUser;

                ctx.UserInfos.Update(userFetched);
                ctx.SaveChanges();
            }
        }
    }
}
