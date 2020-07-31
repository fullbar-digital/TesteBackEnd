using System;

namespace ApplicationCore.Domain.Shared
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}