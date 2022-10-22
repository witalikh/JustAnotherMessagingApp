using Microsoft.EntityFrameworkCore;
using MessangerApp.Models.Chats;

namespace MessangerApp.DataAccess.Chats.Contexts;

public class ChatInvitationPostgreSqlContext : DbContext
{
    public ChatInvitationPostgreSqlContext(DbContextOptions<ChatInvitationPostgreSqlContext> options)
        : base(options)
    {
    }

    public DbSet<ChatInvitation> ChatInvitations { get; set; }

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
