using Pipocao.Persistence.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Pipocao.Database.Model.Mapping
{
    public class ReviewMap : EntityTypeConfiguration<Review>
    {
        public ReviewMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(t => t.Note)
                .IsRequired();

            this.Property(t => t.Commentary);

            this.Property(t => t.ReviewDate)
                .IsRequired();

            this.HasRequired(t => t.Movie)
                .WithMany(b => b.Reviews)
                .WillCascadeOnDelete(true);

            this.HasRequired(t => t.User);

            this.ToTable("REVIEW");
        }
    }
}
