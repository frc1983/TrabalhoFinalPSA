using Business;
using Business.Exceptions;
using Entities;
using Pipocao.Business;
using Pipocao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipocao.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult List(int? page)
        {
            if (!page.HasValue) page = 1;

            MovieBusiness movieBusiness = new MovieBusiness();
            var listMovies = movieBusiness.List(page.Value);
            var listFromUser = new List<MovieViewModel>();

            if (User.Identity.IsAuthenticated)
                listFromUser = MovieViewModel.Parse(movieBusiness.ListFromUser(User.Identity.Name));

            var MoviesVM = MovieViewModel.Parse(listMovies);

            foreach (MovieViewModel myMovie in listFromUser)
                foreach (MovieViewModel mvm in MoviesVM)
                    if (myMovie.id.Equals(mvm.id))
                        mvm.IsVisible = false;

            return View(MoviesVM);
        }

        public ActionResult Detail(int id)
        {
            var movie = new MovieBusiness().GetById(id);
            var comments = new ReviewBusiness().GetAllByMovieId(id);

            return View(new MovieViewModel(movie, comments));
        }

        public ActionResult ListFromUser()
        {
            var listMovies = new List<Movie>();

            if (User.Identity.IsAuthenticated)
                listMovies = new MovieBusiness().ListFromUser(User.Identity.Name);

            var MoviesVM = MovieViewModel.Parse(listMovies);
            MoviesVM.ForEach(x => x.IsVisible = false);

            return View("List", MoviesVM);
        }

        [HttpPost]
        public JsonResult AddMovie(Int32 id)
        {
            try
            {
                new MovieBusiness().InsertMovie(id, User.Identity.Name);
                return Json(new { Success = true });
            }
            catch (MovieBusinessException e)
            {
                return Json(new { Success = false, Message = e.Message });
            }
        }

        [HttpPost]
        public JsonResult SendComment(Int32 movieId, Int32 rate, String comment)
        {
            try
            {
                new ReviewBusiness().InsertMovieCommentary(User.Identity.Name, movieId, rate, comment);
                return Json(new { Success = true });
            }
            catch (ReviewBusinessException e)
            {
                return Json(new { Success = false, Message = e.Message });
            }
        }
    }
}
