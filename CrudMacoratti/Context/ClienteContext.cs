using CrudMacoratti.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudMacoratti.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions options ) : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
