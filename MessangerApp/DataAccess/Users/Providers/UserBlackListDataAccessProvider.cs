using MessangerApp.Entities.Users;
using MessangerApp.DataAccess.Users.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Users.Providers;

public class UserBlacklistDataAccessProvider : IUserBlacklistDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public UserBlacklistDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddUserBlacklistRecord(UserBlacklist UserBlacklist)
    {
        _context.UserBlacklists.Add(UserBlacklist);
        _context.SaveChanges();
    }

    public void AddRange(List<UserBlacklist> UserBlacklists)
    {
        _context.UserBlacklists.AddRange(UserBlacklists);
        _context.SaveChanges();
    }

    public void UpdateUserBlacklistRecord(UserBlacklist UserBlacklist)
    {
        _context.UserBlacklists.Update(UserBlacklist);
        _context.SaveChanges();
    }

    public void DeleteUserBlacklistRecord(int id)
    {
        var entity = _context.UserBlacklists.FirstOrDefault(t => t.Id == id);
        _context.UserBlacklists.Remove(entity!);
        _context.SaveChanges();
    }

    public UserBlacklist GetUserBlacklistSingleRecord(int id)
    {
        return _context.UserBlacklists.FirstOrDefault(t => t.Id == id);
    }

    public List<UserBlacklist> GetUserBlacklistRecords()
    {
        return _context.UserBlacklists.ToList();
    }
}
