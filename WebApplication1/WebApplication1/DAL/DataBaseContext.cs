using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL
{
    public class DataBaseContext : DbContext

    {
        //asi se conecta a la base de datos por medio de un costructor
        public DataBaseContext(DbContextOptions<DataBaseContext>options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); // asi creo index para el campo name de la tabla country
        }


        public DbSet<Country> Countries { get; set; }

        #endregion 
    }
}
