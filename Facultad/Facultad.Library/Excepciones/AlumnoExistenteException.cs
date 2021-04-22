using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Excepciones
{
    public class AlumnoExistenteException : Exception
    {
        public AlumnoExistenteException() : base()
        {

        }

        public AlumnoExistenteException(string message) : base(message) { }
    }
}
