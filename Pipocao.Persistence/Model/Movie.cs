namespace Pipocao.Persistence.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MOVIE")]
    public partial class Movie
    {
        public Movie()
        {
            this.Reviews = new List<Review>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
