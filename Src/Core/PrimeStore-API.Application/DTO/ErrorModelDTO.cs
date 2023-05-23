using System.Text.Json;

namespace PrimeStore_API.Application.DTO
{
    public class ErrorModelDTO
    {
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
