using Microsoft.EntityFrameworkCore;
using Vendors.Models;
namespace Vendors.Data
{
    public class ApiContext:DbContext
    {
        public DbSet<VendorDetails>Vendors { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
        :base(options)
        {
        }
    }
}
