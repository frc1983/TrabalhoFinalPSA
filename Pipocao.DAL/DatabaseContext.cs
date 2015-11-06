namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DAL.Model.Mapping;
    using DAL.Model;

    public partial class DatabaseContext : DbContext, IDisposable
    {
        public DatabaseContext() : base("name=DatabaseContext")
        {
            //Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseAlways<DatabaseContext>());
            //Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCollection> UserCollection { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        //public virtual DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserCollectionMap());
            modelBuilder.Configurations.Add(new ReviewMap());
            //modelBuilder.Configurations.Add(new MovieMap());
        }

    }
}
