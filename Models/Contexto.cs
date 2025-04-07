using Microsoft.EntityFrameworkCore;

namespace Atividade_1.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cultura> Culturas { get; set; }

    }
}
