using Microsoft.EntityFrameworkCore;
using WebApiFuncionarios.Models;

namespace WebApiFuncionarios.DataContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
   
        }

        public DbSet<FuncionarioModels> FuncionarioModels { get; set; }
    }
}
