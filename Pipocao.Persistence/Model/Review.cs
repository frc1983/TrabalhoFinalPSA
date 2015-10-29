namespace Pipocao.Persistence.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REVIEW")]
    public partial class Review
    {
        public int Id { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        [Required]
        [Range(1, 5)]
        public int Note { get; set; }

        public string Commentary { get; set; }        
    }
}
