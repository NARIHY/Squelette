using MySql.Data.MySqlClient;
using Squelette.Models.Entities.User;
using Squelette.Repositories.Interfaces.Users;

namespace Squelette.Repositories.Implementations.Users
{
    public class UsersConnexionRepository : IUsersConnexionRepositoryInterface
    {
        private static string connectionString = "server=localhost;port=3306;database=Squelette;user=superuser;password=monpassword;SslMode=none;";

        public Models.Entities.User.UsersEntity? GetUser(string matricule, string password)
        {
            Models.Entities.User.UsersEntity? user = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, matricule, nom, role FROM lovox_users WHERE matricule = @matricule AND password = @password LIMIT 1";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@matricule", matricule);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Models.Entities.User.UsersEntity
                            {
                                Id = reader.GetInt32("id"),
                                Matricule = reader.GetString("matricule"),
                                Nom = reader.GetString("nom"),
                                Role = reader.GetString("role")
                            };
                        }
                    }
                }
            }

            return user;
        }

        public int LogUserLogin(int userId, string machineName, string machineIp)
        {
            int logId = -1;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO user_logs (user_id, machine_name,ip, login_time) VALUES (@userId, @machineName,@ip, NOW()); SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@machineName", machineName);
                    cmd.Parameters.AddWithValue("@ip", machineIp);
                    logId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return logId;
        }

        public void LogUserLogout(int logId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE user_logs SET logout_time = NOW() WHERE id = @logId";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@logId", logId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}
