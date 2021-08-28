using System;
using System.Threading.Tasks;

namespace Services.Result
{
    public class BaseResult
    {
        protected Task<TResponse<T>> Ok<T>(T data)
        {
            return Task.FromResult(new TResponse<T>
            {
                Data = data,
                IsSuccess = true,
                Message = string.Empty
            });
        }

        protected Task<TResponse<T>> Ok<T>(TResponse<T> data)
        {
            return Task.FromResult(data);
        }

        protected Task<TResponse<T>> Fail<T>(Exception ex)
        {
            return Task.FromResult(new TResponse<T>
            {
                Data = default,
                IsSuccess = false,
                Message = ex.ToString()
            });
        }

        protected Task<TResponse<T>> Fail<T>(string message)
        {
            return Task.FromResult(new TResponse<T>
            {
                Data = default,
                IsSuccess = false,
                Message = message
            });
        }
    }
}