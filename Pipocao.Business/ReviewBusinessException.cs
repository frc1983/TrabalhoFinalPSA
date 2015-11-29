using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipocao.Business
{
    public class ReviewBusinessException : Exception
    {
        public ReviewBusinessException()
        {
        }

        public ReviewBusinessException(string message) : base(message)
        {
        }

        public ReviewBusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
