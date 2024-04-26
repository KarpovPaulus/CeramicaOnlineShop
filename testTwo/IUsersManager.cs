using testTwo.Models;

namespace testTwo
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        void ChangePassword(string userName, string newPassword);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
    }
}
