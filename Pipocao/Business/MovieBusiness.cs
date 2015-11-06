using Business.Exceptions;
using DAL;
using DAL.Model;
using Pipocao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDBService;
using TMDBService.Models;

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

        public List<MovieViewModel> List(int page)
        {
            List<MovieViewModel> movies = new List<MovieViewModel>();
            var list = MovieServiceFacade.Instance.List(page);
            if (list == null)
                throw new Exception("Nenhum filme encontrado.");

            foreach (var movie in list)
                movies.Add(new MovieViewModel(movie));

            return movies;
        }

        public MovieViewModel GetById(int id)
        {
            return new MovieViewModel(MovieServiceFacade.Instance.GetById(id));
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

        internal List<MovieViewModel> List(int page, string login)
        {
            using (var ctx = new DatabaseContext())
            {
                var user = ctx.User.Where(x => x.Email.ToLower().Equals(login)).First();
                if (user == null)
                    throw new MovieBusinessException("Usuário não cadastrado.");

                var userMovies = ctx.UserCollection.Where(x => x.User.Id.Equals(user.Id)).ToList();

                if (userMovies == null)
                    throw new MovieBusinessException("Nenhum filme cadastrado na sua coleção.");

                var allMovies = List(page);
                foreach (MovieViewModel item in allMovies)
                    foreach (UserCollection movieUser in userMovies)
                        if (item.id == movieUser.MovieId)
                            item.IsVisible = false;

                return allMovies;
            }
        }

        internal List<MovieViewModel> ListFromUser(string login)
        {
            using (var ctx = new DatabaseContext())
            {
                var user = ctx.User.Where(x => x.Email.ToLower().Equals(login)).First();
                if (user == null)
                    throw new MovieBusinessException("Usuário não cadastrado.");

                var userMovies = ctx.UserCollection.Where(x => x.User.Id.Equals(user.Id)).ToList();

                if (userMovies == null)
                    throw new MovieBusinessException("Nenhum filme cadastrado na sua coleção.");

                var listMovies = new List<MovieViewModel>();
                foreach (UserCollection movieUser in userMovies)
                    listMovies.Add(new MovieViewModel(MovieServiceFacade.Instance.GetById(movieUser.MovieId)));

                return listMovies;
            }
        }
    }
}
