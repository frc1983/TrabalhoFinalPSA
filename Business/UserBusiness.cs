using Business.Exceptions;
using Pipocao.DAL;
using Pipocao.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private static UserBusiness instance;
        public static UserBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserBusiness();
                }
                return instance;
            }
        }

        public bool Login(String email, String pass)
        {
            var exists = new UserRepository().ExistsUser(CreateUserInstance(email, pass));
            if (!exists)
                throw new UserBusinessException("Usuário não cadastrado.");

            return exists;
        }

        public bool ExistsUser(String email)
        {
            return new UserRepository().ExistsLogin(CreateUserInstance(email, String.Empty));
        }

        public void InsertUser(String email)
        {
            using (var ctx = new DatabaseContext())
            {
                if (ExistsUser(email))
                    throw new UserBusinessException("Email já cadastrado.");
                ctx.User.Add(user);
                ctx.SaveChanges();
            }
        }

        private User CreateUserInstance(String email, String pass)
        {
            User u = new User();
            u.Email = email;
            u.Password = pass;

            return u;
        }
    }
}
