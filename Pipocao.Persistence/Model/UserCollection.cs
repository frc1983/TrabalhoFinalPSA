namespace Pipocao.Persistence.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER_COLLECTION")]
    public partial class UserCollection
    {
        public int Id { get; set; }

        [Required]
        public Movie Movie { get; set; }
        
        [Required]
        public virtual User User { get; set; }
    }
}
