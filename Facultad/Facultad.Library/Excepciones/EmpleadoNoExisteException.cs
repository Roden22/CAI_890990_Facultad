using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Excepciones
{
    public class EmpleadoNoExisteException : Exception
    {
        public EmpleadoNoExisteException() : base() { }
        public EmpleadoNoExisteException(string message) : base(message) { }
    }
}
