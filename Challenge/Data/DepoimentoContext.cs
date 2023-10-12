using Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Data
{
    public class DepoimentoContext : DbContext
    {
        public DepoimentoContext(DbContextOptions<DepoimentoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depoimentos>().HasKey(depoimento => depoimento.Id);
        }
        public DbSet<Depoimentos> Depoimentos { get; set; }
    }
}