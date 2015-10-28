using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMDBService;

namespace Pipocao.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult List()
        {
            IMovieService service = new MovieService();
            var list = service.getMoviesAsync("discover/movie", new Dictionary<string, string>() { { "page", "1" } }).Result;

            return View(list);
        }

        public ActionResult Detail(int id)
        {
            IMovieService service = new MovieService();
            var movie = service.getMovieAsync("movie/" + id, new Dictionary<string, string>()).Result;

            return View(movie);
        }
    }
}
