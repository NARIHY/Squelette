using Squelette.Models.Entities.User;
using Squelette.Repositories.Interfaces.Users;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Squelette.Repositories.Implementations.Users.UsersConnexionRepository;

namespace Squelette.Repositories.Implementations.Users
{
    public class LoginInfoRepository : ILoginInfoRepository
    {
        private static string connectionString = "server=localhost;port=3306;database=Squelette;user=superuser;password=monpassword;SslMode=none;";

        public LoginInfoEntity? GetLoginInfoByMatricule(string matricule)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT login_c3x, password_c3x, login_voxco, password_voxco FROM login_infos WHERE matricule = @matricule LIMIT 1";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@matricule", matricule);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new LoginInfoEntity
                            {
                                LoginC3X = reader["login_c3x"]?.ToString() ?? string.Empty,
                                PasswordC3X = reader["password_c3x"]?.ToString() ?? string.Empty,
                                LoginVoxco = reader["login_voxco"]?.ToString() ?? string.Empty,
                                PasswordVoxco = reader["password_voxco"]?.ToString() ?? string.Empty,
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
