using System.ComponentModel.DataAnnotations;

namespace Autenticacao.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Nome { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}
