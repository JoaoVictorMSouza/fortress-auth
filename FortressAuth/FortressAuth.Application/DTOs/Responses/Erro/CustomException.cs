namespace FortressAuth.Application.DTOs.Responses.Erro
{
    public class CustomException : Exception
    {
        public CustomException(string message, IEnumerable<string> details) : base(message)
        {
            Details = new List<string>();
            AddDetails(details);
        }

        public CustomException(string message, string detail) : this(message, new List<string>() { detail })
        {

        }

        public CustomException(string message) : this(message, new List<string>())
        {
            
        }

        public List<string> Details { get; set; }

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
