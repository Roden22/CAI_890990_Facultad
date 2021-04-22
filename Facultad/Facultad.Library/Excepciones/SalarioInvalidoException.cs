using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Excepciones
{
    class SalarioInvalidoException : Exception
    {
        public SalarioInvalidoException() : base() { }
        public SalarioInvalidoException(string message) : base(message) { }
    }
}
