using Microsoft.EntityFrameworkCore;
using MessangerApp.Models.Chats;

namespace MessangerApp.DataAccess.Chats.Contexts;

public class ChatJoinRequestPostgreSqlContext : DbContext
{
    public ChatJoinRequestPostgreSqlContext(DbContextOptions<ChatJoinRequestPostgreSqlContext> options)
        : base(options)
    {
    }

    public DbSet<ChatJoinRequest> ChatJoinRequests { get; set; }

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
