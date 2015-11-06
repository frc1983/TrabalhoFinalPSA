using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class MovieBusinessException : Exception
    {
        public MovieBusinessException()
        {
        }

        public MovieBusinessException(string message) : base(message)
        {
        }

        public MovieBusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
