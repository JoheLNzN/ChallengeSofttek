using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace JncSofttek.Microservice.Common.Classes
{
    public class DefaultResponse<T> where T : class
    {
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ExecutionTime { get; set; } = DateTime.Now;
        public bool IsSuccess { get; set; }

        public DefaultResponse() { }
        public DefaultResponse(bool isSuccess, T result = null, string errorMessage = null)
        {
            IsSuccess = isSuccess;
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}
