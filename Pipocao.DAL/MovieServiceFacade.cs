using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDBService;

namespace TMDBService
{
    public class MovieServiceFacade
    {
        private static MovieServiceFacade instance;
        public static MovieServiceFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MovieServiceFacade();
                }
                return instance;
            }
        }

        public List<Movie> List(int page)
        {
            IMovieService service = new MovieService();
            return service.getMoviesAsync("discover/movie", new Dictionary<string, string>() { { "page", page.ToString() } }).Result;
        }

        public Movie GetById(int id)
        {
            IMovieService service = new MovieService();
            return service.getMovieAsync("movie/" + id, new Dictionary<string, string>()).Result;
        }
    }
}
