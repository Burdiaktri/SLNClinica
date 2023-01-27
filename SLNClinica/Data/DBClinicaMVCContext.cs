using Microsoft.EntityFrameworkCore;
using SLNClinica.Models;

namespace SLNClinica.Data
{
    public class DBClinicaMVCContext : DbContext
    {
        public DBClinicaMVCContext(DbContextOptions<DBClinicaMVCContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
    }
}
