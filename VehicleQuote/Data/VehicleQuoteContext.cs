using Microsoft.EntityFrameworkCore;
using VehicleQuote.Models;

namespace VehicleQuote.Data
{
    public class VehicleQuoteContext: DbContext
    {
        public VehicleQuoteContext(DbContextOptions<VehicleQuoteContext> options): base(options)
        {
            
        }
        
        public DbSet<Make> Makes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
    }
}