namespace FortressAuth.Application.DTOs.Responses.Erro
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
}
