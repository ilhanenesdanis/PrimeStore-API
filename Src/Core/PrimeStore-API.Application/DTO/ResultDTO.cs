using System.Text.Json.Serialization;

namespace PrimeStore_API.Application.DTO
{
    public class ResultDTO<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public static ResultDTO<T> Success(int StatusCode, T data)
        {
            return new ResultDTO<T> { StatusCode = StatusCode, Data = data };
        }
        public static ResultDTO<T> Success(int StatusCode)
        {
            return new ResultDTO<T> { StatusCode = StatusCode };
        }
        public static ResultDTO<T> Fail(List<string> Errors, int statusCode)
        {
            return new ResultDTO<T> { Errors = Errors, StatusCode = statusCode };
        }
        public static ResultDTO<T> Fail(int statusCode, string error)
        {
            return new ResultDTO<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
