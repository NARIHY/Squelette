using Squelette.Models.Entities.User;
using Squelette.Repositories.Implementations.Users;

namespace Squelette.Repositories.Interfaces.Users
{
    public interface IUsersConnexionRepositoryInterface
    {
        UsersEntity? GetUser(string matricule, string password);
        int LogUserLogin(int userId, string machineName, string machineIp);
        void LogUserLogout(int logId);
        //UsersConnexionRepository.LoginInfo? GetLoginInfoByMatricule(string matricule);
    }
}
