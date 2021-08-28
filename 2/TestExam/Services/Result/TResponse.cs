﻿namespace Services.Result
{
    public class TResponse<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}