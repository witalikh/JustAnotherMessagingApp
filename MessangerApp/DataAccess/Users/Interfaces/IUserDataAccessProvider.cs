namespace MessangerApp.DataAccess.Users;

using MessangerApp.Models.Users;

public interface IUserDataAccessProvider
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Register(RegisterRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}
