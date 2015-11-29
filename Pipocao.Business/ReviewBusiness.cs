using DAL;
using Entities;
using Pipocao.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipocao.Business
{
    public class ReviewBusiness
    {
        public void InsertMovieCommentary(string login, int movieId, int rate, string comment)
        {
            var user = new UserRepository().FindByEmail(login);
            if (user == null)
                throw new ReviewBusinessException("Usuário não cadastrado.");

            ReviewRepository reviewRepository = new ReviewRepository();
            reviewRepository.InsertMovieCommentary(user, movieId, rate, comment);
        }

        public List<Review> GetAllByMovieId(int id)
        {
            ReviewRepository reviewRepository = new ReviewRepository();
            return reviewRepository.GetMovieCommentary(id);
        }
    }
}
