namespace Squelette.Models.Entities.User
{
    public class UsersEntity
    {
        public int Id { get; set; }
        public string Matricule { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Role { get; set; } = "client";
    }
}
