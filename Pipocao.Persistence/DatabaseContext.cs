namespace Pipocao.Persistence
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Pipocao.Persistence.Model;
    using Pipocao.Database.Model.Mapping;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DatabaseContext")
        {            
        }

        public virtual DbSet<User> USER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap()); 
        }
    }
}
