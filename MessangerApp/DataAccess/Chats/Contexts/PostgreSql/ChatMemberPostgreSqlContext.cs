using Microsoft.EntityFrameworkCore;
using MessangerApp.Models.Chats;

namespace MessangerApp.DataAccess.Chats.Contexts;

public class ChatMemberPostgreSqlContext : DbContext
{
    public ChatMemberPostgreSqlContext(DbContextOptions<ChatMemberPostgreSqlContext> options)
        : base(options)
    {
    }

    public DbSet<ChatMember> ChatMembers { get; set; }

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
