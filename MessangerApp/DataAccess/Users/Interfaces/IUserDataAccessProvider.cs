using MessangerApp.Models.Users;
using MessangerApp.Entities.Users;

namespace MessangerApp.DataAccess.Users.Interfaces;

public interface IUserDataAccessProvider
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Register(RegisterRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}
