using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Entidades
{
    public class Alumno : Persona
    {
        // ATRIBUTOS
        protected int _codigo;

        // PROPIEDADES
        public int Codigo => _codigo;


        // MÉTODOS
        public Alumno(string nombre, string apellido, int codigo, DateTime fechaNac = new DateTime()) : base(nombre, apellido, fechaNac)
        {
            if (codigo <= 0)
                throw new ArgumentException("El código del alumno debe ser entero mayor a cero.");

            _codigo = codigo;
        }

        public override string GetCredencial()
        {
            return $"Código {_codigo}) {_apellido}, {_nombre}";
        }


        public override string ToString()
        {
            return GetCredencial();
        }
    }
}
