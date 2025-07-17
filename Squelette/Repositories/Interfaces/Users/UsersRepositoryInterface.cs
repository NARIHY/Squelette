using Squelette.Models.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squelette.Repositories.Interfaces.Users
{
    public interface UsersRepositoryInterface
    {
        UsersLovoxEntity[] GetUserAllUsers();
        UsersLovoxEntity? GetUserById(int id);
        void UpdateUser(UsersLovoxEntity user);
        void DeleteUser(int id, UsersLovoxEntity user);
        UsersLovoxEntity? CreateUser(UsersLovoxEntity user);
    }
}
