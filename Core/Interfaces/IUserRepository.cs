using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Get(string fingerprint);
        Task<User> Add(User s);
        Task<User> Update(User s);
        Task<bool> Delete(int id);
    }
}
