using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class UserBusinessException : Exception
    {
        public UserBusinessException()
        {
        }

        public UserBusinessException(string message) : base(message)
        {
        }

        public UserBusinessException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
