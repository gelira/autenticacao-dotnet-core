using System.ComponentModel.DataAnnotations;

namespace Autenticacao.Models
{
    public class LoginUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
