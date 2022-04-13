using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autorizacao
{
    public class AppContext : IdentityDbContext
    {
        public AppContext(DbContextOptions<AppContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
