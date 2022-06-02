using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Application.Handlers.Exceptions
{
    public class LockException : Exception
    {
        public LockException(string message) : base(message)
        {
        }
    }
}
