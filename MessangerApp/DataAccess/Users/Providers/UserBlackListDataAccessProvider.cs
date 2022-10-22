using MessangerApp.Models.Users;
using MessangerApp.DataAccess.Users.Interfaces;
using MessangerApp.DataAccess.Users.Contexts;

namespace MessangerApp.DataAccess.Users.Providers;

public class UserBlackListDataAccessProvider : IUserBlackListDataAccessProvider
{
    private readonly UserBlackListPostgreSqlContext _context;

    public UserBlackListDataAccessProvider(UserBlackListPostgreSqlContext context)
    {
        _context = context;
    }

    public void AddUserBlackListRecord(UserBlackList UserBlackList)
    {
        _context.UserBlackLists.Add(UserBlackList);
        _context.SaveChanges();
    }

    public void AddRange(List<UserBlackList> UserBlackLists)
    {
        _context.UserBlackLists.AddRange(UserBlackLists);
        _context.SaveChanges();
    }

    public void UpdateUserBlackListRecord(UserBlackList UserBlackList)
    {
        _context.UserBlackLists.Update(UserBlackList);
        _context.SaveChanges();
    }

    public void DeleteUserBlackListRecord(int id)
    {
        var entity = _context.UserBlackLists.FirstOrDefault(t => t.Id == id);
        _context.UserBlackLists.Remove(entity!);
        _context.SaveChanges();
    }

    public UserBlackList GetUserBlackListSingleRecord(int id)
    {
        return _context.UserBlackLists.FirstOrDefault(t => t.Id == id);
    }

    public List<UserBlackList> GetUserBlackListRecords()
    {
        return _context.UserBlackLists.ToList();
    }
}
