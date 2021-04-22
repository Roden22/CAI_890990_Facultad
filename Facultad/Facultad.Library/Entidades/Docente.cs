using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Entidades
{
    public class Docente : Empleado
    {
        public Docente(string nombre,
            string apellido,
            DateTime fechaIngreso,
            int legajo,
            DateTime fechaNac) : base(nombre, apellido, fechaIngreso, legajo, fechaNac)
        {

        }

        public override string GetNombreCompleto()
        {
            return $"Docente {_apellido}";
        }
    }
}
