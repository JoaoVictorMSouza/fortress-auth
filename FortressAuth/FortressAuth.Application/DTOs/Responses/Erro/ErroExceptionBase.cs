using System.Net;

namespace FortressAuth.Application.DTOs.Responses.Erro
{
    public class ErroExceptionBase
    {
        public ErroExceptionBase(HttpStatusCode httpStatusCode, string message, IEnumerable<string> details)
        {
            TraceId = Guid.NewGuid().ToString();
            Message = message;
            Details = new List<string>();
            StatusCode = (int)httpStatusCode;
            Description = httpStatusCode.ToString();
            AddDetails(details);
        }

        public ErroExceptionBase(HttpStatusCode httpStatusCode, string message, string detail) : this(httpStatusCode, message, new List<string>() { detail })
        {

        }

        public ErroExceptionBase(HttpStatusCode httpStatusCode, string message) : this(httpStatusCode, message, new List<string>())
        {
            
        }

        public string TraceId { get; set; }
        public string Message { get; set; }
        public List<string> Details { get; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }

        private void AddDetails(IEnumerable<string> messages)
        {
            foreach (string message in messages)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    Details.Add(message);
                }
            }
        }
    }
}
