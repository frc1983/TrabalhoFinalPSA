using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository
    {
        private static UserRepository instance;
        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRepository();
                }
                return instance;
            }
        }

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
