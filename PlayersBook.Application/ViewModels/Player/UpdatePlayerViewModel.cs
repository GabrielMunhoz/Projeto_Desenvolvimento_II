namespace PlayersBook.Application.ViewModels.Player
{
    public class UpdatePlayerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
