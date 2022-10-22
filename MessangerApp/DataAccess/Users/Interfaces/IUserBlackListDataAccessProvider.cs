using MessangerApp.Models.Users;

namespace MessangerApp.DataAccess.Users.Interfaces;

public interface IUserBlackListDataAccessProvider
{
    void AddUserBlackListRecord(UserBlackList userBlackList);
    void AddRange(List<UserBlackList> userBlackLists);
    void UpdateUserBlackListRecord(UserBlackList userBlackList);
    void DeleteUserBlackListRecord(int id);
    UserBlackList GetUserBlackListSingleRecord(int id);
    List<UserBlackList> GetUserBlackListRecords();
}
