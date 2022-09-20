namespace PlayersBook.Domain.Models.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
