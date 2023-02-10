﻿namespace SocialNetwork.Domain.Common
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
