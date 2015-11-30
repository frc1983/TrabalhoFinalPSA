using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipocao.DAL
{
    public class MovieRepositoryException : Exception
    {
        public MovieRepositoryException()
        {
        }

        public MovieRepositoryException(string message) : base(message)
        {
        }

        public MovieRepositoryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
