namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("USER_COLLECTION")]
    public partial class UserCollection
    {
        public int Id { get; set; }

        [Required]
        public Int32 MovieId { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
