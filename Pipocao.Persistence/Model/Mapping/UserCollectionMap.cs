using Pipocao.Persistence.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Pipocao.Database.Model.Mapping
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

            this.HasRequired(t => t.Movie);

            this.ToTable("USER_COLLECTION");
        }
    }
}
