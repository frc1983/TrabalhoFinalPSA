using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Pipocao.DAL.Model.Mapping
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            this.Property(t => t.Name)
                .IsRequired();

            this.HasOptional(t => t.Reviews)
                .WithMany();

            this.ToTable("MOVIE");
        }
    }
}
