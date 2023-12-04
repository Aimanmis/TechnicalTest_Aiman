using Microsoft.EntityFrameworkCore;
using TechnicalTest_Aiman.Models;

namespace TechnicalTest_Aiman.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<tbl_user> tbl_user { get; set; }
    }

}




