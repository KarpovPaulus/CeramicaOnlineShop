using testTwo.Areas.Admin.Models;

namespace testTwo
{
    public interface IRolesRepository
    {
        List<Role> GetAll();

        Role TryGetByName(string name);

        void Add(Role role);
        void Remove(string name);
    }
}
