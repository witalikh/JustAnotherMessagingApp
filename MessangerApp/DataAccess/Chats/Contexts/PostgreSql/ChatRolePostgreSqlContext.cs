using Microsoft.EntityFrameworkCore;
using MessangerApp.Models.Chats;

namespace MessangerApp.DataAccess.Chats.Contexts;

public class ChatRolePostgreSqlContext : DbContext
{
    public ChatRolePostgreSqlContext(DbContextOptions<ChatRolePostgreSqlContext> options)
        : base(options)
    {
    }

    public DbSet<ChatRole> ChatRoles { get; set; }

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
