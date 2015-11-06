using Business.Exceptions;
using DAL;
using DAL.Model;
using Pipocao.ViewModels;
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

        public void Login(UserViewModel u)
        {
            User user = UserRepository.Instance.Find(Parse(u));
            if (user == null)
                throw new UserBusinessException("Usuário não cadastrado.");
        }

        public bool Insert(UserViewModel u)
        {
            User newUser = Parse(u);
            User userFound = UserRepository.Instance.Find(newUser);
            if (userFound != null)
                throw new UserBusinessException("Email já cadastrado.");

            return UserRepository.Instance.Insert(newUser);
        }

        public static User Parse(UserViewModel viewModel)
        {
            User user = new User();
            user.Email = viewModel.Email;
            user.Password = viewModel.Password;

            return user;
        }
    }
}
