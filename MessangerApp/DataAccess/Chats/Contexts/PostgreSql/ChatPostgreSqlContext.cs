using Microsoft.EntityFrameworkCore;
using MessangerApp.Models.Chats;

namespace MessangerApp.DataAccess.Chats.Contexts;

public class ChatPostgreSqlContext : DbContext
{
    public ChatPostgreSqlContext(DbContextOptions<ChatPostgreSqlContext> options)
        : base(options)
    {
    }

    public DbSet<Chat> Chats { get; set; }

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
