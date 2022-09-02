using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }

        public DbSet<Curso> cursos { get; set; }
    }
}
