using DBModel.Models;

namespace WebCalc.Managers
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Validate(string userName, string password);
    }
}
