using Microsoft.EntityFrameworkCore;
using Music;

namespace RestAPI.Models
{
    public class RecordDBContext : DbContext
    {

        public DbSet<RecordDB> Records { get; set; }

        public RecordDBContext(DbContextOptions<RecordDBContext> options): base(options)
        {
        }
    }
}
