using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class CopagoContext : DbContext
    {

        public CopagoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Copago> Copagos { get; set; }
	}

}