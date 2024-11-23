#pragma warning disable IDE0290
using Microsoft.EntityFrameworkCore;
using TelRehAPI.Models.Domain;
namespace TelRehAPI.Data{
    public class TelDbContext:DbContext{
        public TelDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<LogEntry> LogEntries { get; set; } 
    }
}
