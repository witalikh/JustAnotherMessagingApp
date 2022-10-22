using Microsoft.EntityFrameworkCore;
using MessangerApp.Models.Users;

namespace MessangerApp.DataAccess.Users;

public class UserPostgreSqlContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserPostgreSqlContext(DbContextOptions<UserPostgreSqlContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
			.HasMany(x => x.UserBlackLists)
			.WithOne(x => x.User)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>()
			.HasMany(x => x.BlacklistedUsers)
			.WithOne(x => x.BlacklistedUser)
			.HasForeignKey(x => x.BlacklistedUserId)
			.OnDelete(DeleteBehavior.Restrict);
    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        return base.SaveChanges();
    }
}
