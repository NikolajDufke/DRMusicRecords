using Microsoft.EntityFrameworkCore;
using Music;

namespace RestAPI.Models
{
    public class RecordDBContext : DbContext
    {

        public DbSet<Record> Records { get; set; }

        public RecordDBContext(DbContextOptions<RecordDBContext> options): base(options)
        {
        }
    }
}
