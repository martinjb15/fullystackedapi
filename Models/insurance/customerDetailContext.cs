using Microsoft.EntityFrameworkCore;

namespace fullystackedapi.Models.insurance
{
    public class customerDetailContext : DbContext
    {
        // create db context class
        public customerDetailContext(DbContextOptions<customerDetailContext> options) : base(options)
        { }

        public DbSet<CustomerDetail> CustomerDetails { get; set; }

    }
}
