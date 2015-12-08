using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDBService;

namespace Pipocao.DAL
{
    public class MovieRepository
    {
        public List<Movie> List(int page)
        {
            var list = MovieServiceFacade.Instance.List(page);
            if (list == null)
                throw new Exception("Nenhum filme encontrado.");

            return list;
        }

        public Movie GetById(int id)
        {
            return MovieServiceFacade.Instance.GetById(id);
        }

        public void InsertMovie(Int32 movieId, User user)
        {
            using (var ctx = new DatabaseContext())
            {
                user = ctx.User.Where(x => x.Email.ToLower().Equals(user.Email.ToLower())).FirstOrDefault();
                ctx.UserCollection.Add(new UserCollection() { User = user, MovieId = movieId });
                ctx.SaveChanges();
            }
        }

        public List<Movie> ListFromUser(User user)
        {
            using (var ctx = new DatabaseContext())
            {
                var userMovies = ctx.UserCollection.Where(x => x.User.Id.Equals(user.Id)).ToList();

                if (userMovies == null)
                    throw new Exception("Erro ao consultar sua coleção.");

                var listMovies = new List<Movie>();
                foreach (UserCollection movieUser in userMovies)
                {
                    var movie = MovieServiceFacade.Instance.GetById(movieUser.MovieId);
                    listMovies.Add(movie);
                }

                return listMovies;
            }
        }

        public List<Movie> GetTopTenBestMovies()
        {
            using (var ctx = new DatabaseContext())
            {
                var bests = (from r in ctx.Review
                             group r by r.MovieId into groupIds
                             select new { groupIds.Key, Average = groupIds.Sum(x => x.Note) / groupIds.Count() })
                             .OrderByDescending(x => x.Average)
                             .Take(10)
                             .ToList();

                var listBest = new List<Movie>();
                foreach (var movie in bests)
                    listBest.Add(GetById(movie.Key));

                return listBest;
            }
        }

        public List<Movie> GetTopTenWorstMovies()
        {
            using (var ctx = new DatabaseContext())
            {
                var bests = (from r in ctx.Review
                             group r by r.MovieId into groupIds
                             select new { groupIds.Key, Average = groupIds.Sum(x => x.Note) / groupIds.Count() })
                             .OrderByDescending(x => x.Average)
                             .Take(10)
                             .ToList();

                var worst = (from r in ctx.Review
                             group r by r.MovieId into groupIds
                             select new { groupIds.Key, Average = groupIds.Sum(x => x.Note) / groupIds.Count() })
                             .ToList()
                             .Where(r => !bests.Any(y => y.Key == r.Key))
                             .OrderBy(x => x.Average)
                             .Take(10)
                             .ToList();

                var listWorst = new List<Movie>();
                foreach (var movie in worst)
                    listWorst.Add(GetById(movie.Key));

                return listWorst;
            }
        }

        public void RemoveMovieFromUser(int id, User user)
        {
            using (var ctx = new DatabaseContext())
            {
                var item = ctx.UserCollection.Where(x => x.User.Id == user.Id && x.MovieId == id).FirstOrDefault();

                if (item == null)
                    throw new MovieRepositoryException("Filme não encontrado na lista.");

                ctx.UserCollection.Remove(item);
                ctx.SaveChanges();
            }
        }
    }
}
