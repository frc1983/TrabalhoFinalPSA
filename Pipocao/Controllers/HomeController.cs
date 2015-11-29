using Business;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel();
            homeVM.Top10Best = new List<MovieViewModel>();
            homeVM.Top10Worst = new List<MovieViewModel>();

            var top10 = new MovieBusiness().GetTopTenBestMovies();
            var last10 = new MovieBusiness().GetTopTenWorstMovies();

            foreach(Movie m in top10){
                var reviewBestCount = new ReviewBusiness().GetAllByMovieId(m.id);
                homeVM.Top10Best.Add(new MovieViewModel(m, reviewBestCount));
            }

            foreach (Movie m in last10)
            {
                var reviewBestCount = new ReviewBusiness().GetAllByMovieId(m.id);
                homeVM.Top10Worst.Add(new MovieViewModel(m, reviewBestCount));
            }

            return View(homeVM);
        }
    }
}
