using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squelette.Models.Entities.User
{
    public class UsersLovoxEntity
    {
        public int Id { get; set; }
        public string Matricule { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public string Role { get; set; } = "client";
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt { get; set; } = new DateTime();
    }
}
