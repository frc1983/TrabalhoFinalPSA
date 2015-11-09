using Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Model.Mapping
{
    public class UserCollectionMap : EntityTypeConfiguration<UserCollection>
    {
        public UserCollectionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.Property(p => p.Id)
                .IsRequired();

            this.HasRequired(t => t.User);

            this.Property(t => t.MovieId);

            this.ToTable("USER_COLLECTION");
        }
    }
}
