using Business.Exceptions;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        public void Login(User u)
        {
            User user = new UserRepository().Find(u);
            if (user == null)
                throw new UserBusinessException("Usuário não cadastrado.");
        }

        public bool Insert(User u)
        {
            UserRepository repository = new UserRepository();
            User userFound = repository.Find(u);
            if (userFound != null)
                throw new UserBusinessException("Email já cadastrado.");

            return repository.Insert(u);
        }
    }
}
