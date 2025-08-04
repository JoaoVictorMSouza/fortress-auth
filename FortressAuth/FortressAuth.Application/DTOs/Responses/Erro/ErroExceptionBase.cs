using System.Net;

namespace FortressAuth.Application.DTOs.Responses.Erro
{
    public class ErroExceptionBase
    {
        public ErroExceptionBase(HttpStatusCode httpStatusCode, IEnumerable<string> messages)
        {
            TraceId = Guid.NewGuid().ToString();
            Messages = new List<string>();
            StatusCode = (int)httpStatusCode;
            Description = httpStatusCode.ToString();
        }

        public ErroExceptionBase(HttpStatusCode httpStatusCode, string message) : this(httpStatusCode, new List<string>() { message })
        {

        }

        public string TraceId { get; set; }
        public List<string> Messages { get; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }

        public void AddMessages(IEnumerable<string> messages)
        {
            foreach (string message in messages)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    Messages.Add(message);
                }
            }
        }
    }
}
