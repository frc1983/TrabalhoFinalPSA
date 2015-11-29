using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipocao.DAL
{
    public class ReviewRepository
    {
        public void InsertMovieCommentary(User user, int movieId, int rate, string comment)
        {
            using (var ctx = new DatabaseContext())
            {
                user = ctx.User.Where(x => x.Email.ToLower().Equals(user.Email.ToLower())).FirstOrDefault();
                ctx.Review.Add(new Review() { User = user, MovieId = movieId, Note = rate, Commentary = comment, ReviewDate = DateTime.Now });
                ctx.SaveChanges();
            }
        }

        public List<Review> GetMovieCommentary(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Review.Include("USER").Where(x => x.MovieId == id).ToList();
            }
        }
    }
}
