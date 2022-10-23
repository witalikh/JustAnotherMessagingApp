using Microsoft.EntityFrameworkCore;
using MessangerApp.Entities.Users;
using MessangerApp.Entities.Chats;
using MessangerApp.Entities.Messages;

namespace MessangerApp.DataAccess.Contexts;

public class PostgreSqlContext : DbContext
{
    public DbSet<User> Users { get; set; }
	public DbSet<UserBlacklist> UserBlacklists { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<AdditionalContent> AdditionalContents { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatMember> ChatMembers { get; set; }
    public DbSet<ChatInvitation> ChatInvitations { get; set; }
    public DbSet<ChatJoinRequest> ChatJoinRequests { get; set; }
    public DbSet<ChatRole> ChatRoles { get; set; }
    public DbSet<ChatBlacklist> ChatBlacklists { get; set; }

    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
        : base(options)
    {
    }

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
