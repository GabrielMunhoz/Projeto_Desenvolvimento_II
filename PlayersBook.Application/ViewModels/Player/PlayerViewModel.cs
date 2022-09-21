using System.ComponentModel.DataAnnotations;

namespace PlayersBook.Application.ViewModels.Player
{
    public class PlayerViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
