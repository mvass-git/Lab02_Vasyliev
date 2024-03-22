using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_Vasyliev.Exceptions
{
    internal class PastDateException : Exception
    {
        public PastDateException() { }
        public PastDateException(string message) : base(message) { }
        public PastDateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
