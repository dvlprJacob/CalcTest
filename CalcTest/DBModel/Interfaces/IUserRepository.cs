using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalc.Managers
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Validate(string user, string password);
    }
}
