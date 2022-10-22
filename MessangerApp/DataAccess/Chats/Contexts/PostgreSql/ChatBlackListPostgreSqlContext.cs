using Microsoft.EntityFrameworkCore;
using MessangerApp.Models.Chats;

namespace MessangerApp.DataAccess.Chats.Contexts;

public class ChatBlackListPostgreSqlContext : DbContext
{
    public ChatBlackListPostgreSqlContext(DbContextOptions<ChatBlackListPostgreSqlContext> options)
        : base(options)
    {
    }

    public DbSet<ChatBlackList> ChatBlackLists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        return base.SaveChanges();
    }
}
