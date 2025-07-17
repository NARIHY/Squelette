using Squelette.Models.Entities.User;
using Squelette.Repositories.Implementations.Users;

namespace Squelette.Repositories.Interfaces.Users
{
    public interface ILoginInfoRepository
    {
        LoginInfoEntity? GetLoginInfoByMatricule(string matricule);
    }
}
