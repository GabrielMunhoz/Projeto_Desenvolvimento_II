namespace PlayersBook.Domain.DTOs
{
    public class FileDto
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }
        public string Format { get; private set; }

        public FileDto()
        {

        }
        public FileDto(string url, string format)
        {
            this.Id = new Guid();
            this.Url = url;
            this.Format = format;
        }
    }
}
