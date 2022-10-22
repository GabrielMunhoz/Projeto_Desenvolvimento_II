using System.Net;

namespace PlayersBook.Domain.Models
{
    public class Problem
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
