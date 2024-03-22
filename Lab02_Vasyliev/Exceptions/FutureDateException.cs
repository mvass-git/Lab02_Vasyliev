using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_Vasyliev.Exceptions
{
    internal class FutureDateException : Exception
    {
        public FutureDateException() { }
        public FutureDateException(string message) : base(message) { }
        public FutureDateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
