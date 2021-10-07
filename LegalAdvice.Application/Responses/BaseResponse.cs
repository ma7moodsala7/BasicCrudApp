using System.Collections.Generic;

namespace LegalAdvice.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public List<string> ValidationErrors { get; set; }

        public BaseResponse(bool success = true, string message = null)
        {
            Success = success;
            Message = message;
        }

    }
}
