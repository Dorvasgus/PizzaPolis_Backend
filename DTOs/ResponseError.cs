using Microsoft.AspNetCore.Mvc;

namespace PizzaPolis_01.DTOs
{
    public class ResponseError
    {
        public ResponseError(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ObjectResult GetObjectResult()
        {
            return new ObjectResult(this)
            {
                StatusCode = this.StatusCode,
            };
        }
    }
}
