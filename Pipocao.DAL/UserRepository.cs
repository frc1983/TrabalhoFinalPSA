using DAL.Model;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository
    {
        public User Find(User user)
        {
            using (var ctx = new DatabaseContext())
            {
                var u = ctx.User
                    .Where(x => x.Email.ToLower().Equals(user.Email.ToLower()) && x.Password.Equals(user.Password))
                    .FirstOrDefault();

                return u;
            }
        }

        public User FindByEmail(String login)
        {
            using (var ctx = new DatabaseContext())
            {
                var u = ctx.User
                    .Where(x => x.Email.ToLower().Equals(login.ToLower()))
                    .FirstOrDefault();

                return u;
            }
        }

        public bool Insert(User user)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.User.Add(user);
                int result = ctx.SaveChanges();

                return result >= 1;
            }
        }
    }
}
