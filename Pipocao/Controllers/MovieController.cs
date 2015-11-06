using Business;
using Business.Exceptions;
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
        public ActionResult List()
        {
            var listMovies = new List<MovieViewModel>();

            var list = MovieBusiness.Instance.List(1);
            if (User.Identity.IsAuthenticated)
            {
                listMovies = MovieBusiness.Instance.List(1, User.Identity.Name);
            }
            else
                listMovies = MovieBusiness.Instance.List(1);

            return View(listMovies);
        }

        public ActionResult Detail(int id)
        {
            var movie = MovieBusiness.Instance.GetById(id);

            return View(movie);
        }

        [HttpPost]
        public JsonResult AddMovie(Int32 id)
        {
            try
            {
                var user = User.Identity.Name;
                MovieBusiness.Instance.InsertMovie(id, user);
                return Json(new { Success = true });
            }
            catch (MovieBusinessException e)
            {
                return Json(new { Success = false, Message = e.Message });
            }
        }
    }
}
