using Microsoft.EntityFrameworkCore;

namespace CodeFisrt_CochesEscuderias.Models
{
    public class CircuitosContexto:DbContext
    {
        public DbSet<Coche> Coches { get; set; }
        public DbSet<Escuderia> Escuderias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=Circuitos;Integrated Security=true");
        }
    }
}
