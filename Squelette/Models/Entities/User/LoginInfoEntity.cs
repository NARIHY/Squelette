using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squelette.Models.Entities.User
{
    public class LoginInfoEntity
    {
        public string LoginC3X { get; set; } = string.Empty;
        public string PasswordC3X { get; set; } = string.Empty;
        public string LoginVoxco { get; set; } = string.Empty;
        public string PasswordVoxco { get; set; } = string.Empty;
    }
}
