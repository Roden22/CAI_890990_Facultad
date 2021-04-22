using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Excepciones
{
    public class EmpleadoExistenteException : Exception
    {
        public EmpleadoExistenteException() : base() { }
        public EmpleadoExistenteException(string message) : base(message) { }
    }
}
