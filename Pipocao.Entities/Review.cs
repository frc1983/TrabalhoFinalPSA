namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("REVIEW")]
    public partial class Review
    {
        public int Id { get; set; }

        [Required]
        public Int32 MovieId { get; set; }

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
