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
    public class MovieBusiness
    {
        private static MovieBusiness instance;

        public static MovieBusiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MovieBusiness();
                }
                return instance;
            }
        }

        public List<Movie> GetAll(int page)
        {
            return new MovieServiceFacade().GetAll(page);
        }

        public Movie GetById(int id)
        {
            return new MovieServiceFacade().GetById(id);
        }

        public void InsertMovie(Int32 movieId, String login)
        {
            using (var ctx = new DatabaseContext())
            {
                var user = ctx.User.Where(x => x.Email.ToLower().Equals(login)).First();
                if (user == null)
                    throw new MovieBusinessException("Usuário não cadastrado.");

                var userMovie = ctx.UserCollection.FirstOrDefault(x => x.User.Id.Equals(user.Id) && x.MovieId.Equals(movieId));

                if (userMovie != null)
                    throw new MovieBusinessException("Filme já cadastrado na sua coleção.");


                ctx.UserCollection.Add(new UserCollection() { User = user, MovieId = movieId });
                ctx.SaveChanges();
            }
        }

        public List<UserCollection> ListFromLogged(String login)
        {
            using (var ctx = new DatabaseContext())
            {
                var user = ctx.User.Where(x => x.Email.ToLower().Equals(login)).First();
                if (user == null)
                    throw new MovieBusinessException("Usuário não cadastrado.");

                var userMovie = ctx.UserCollection.Where(x => x.User.Id.Equals(user.Id)).ToList();

                if (userMovie == null)
                    throw new MovieBusinessException("Nenhum filme cadastrado na sua coleção.");
                
                return userMovie;
            }
        }
    }
}
