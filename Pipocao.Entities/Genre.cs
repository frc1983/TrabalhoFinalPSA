using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class GenreResult
    {
        public List<Genre> genres { get; set; }
    }

    public class Genre
    {
        public Int32 id { get; set; }
        public String name { get; set; }
    }
}