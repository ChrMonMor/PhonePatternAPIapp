using Microsoft.EntityFrameworkCore;

namespace PhonePatternAPI.Models
{
    public class PatternContext : DbContext
    {
        public PatternContext(DbContextOptions<PatternContext> options)
            : base(options)
        {
        }

        public DbSet<PhonePattern> PhonePatterns { get; set; } = null!;
    }
}
