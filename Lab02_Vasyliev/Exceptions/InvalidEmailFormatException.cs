using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_Vasyliev.Exceptions
{
    internal class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException() { }
        public InvalidEmailFormatException(string message) : base(message) { }
        public InvalidEmailFormatException(string message, Exception innerException) : base(message, innerException) { }
    }
}
