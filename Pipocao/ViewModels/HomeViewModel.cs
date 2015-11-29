using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pipocao.ViewModels
{
    public class HomeViewModel
    {
        public List<MovieViewModel> Top10Best { get; set; }
        public List<MovieViewModel> Top10Worst { get; set; }
    }
}