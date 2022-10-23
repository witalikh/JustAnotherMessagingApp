using MessangerApp.Entities.Users;

namespace MessangerApp.DataAccess.Users.Interfaces;

public interface IUserBlacklistDataAccessProvider
{
    void AddUserBlacklistRecord(UserBlacklist userBlackList);
    void AddRange(List<UserBlacklist> userBlackLists);
    void UpdateUserBlacklistRecord(UserBlacklist userBlackList);
    void DeleteUserBlacklistRecord(int id);
    UserBlacklist GetUserBlacklistSingleRecord(int id);
    List<UserBlacklist> GetUserBlacklistRecords();
}
