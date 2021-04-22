using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Entidades
{
    public sealed class Bedel : Empleado
    {
        // ATRIBUTOS
        protected string _apodo;

        // PROPIEDADES
        public string Apodo => _apodo;

        // MÉTODOS
        public Bedel(string nombre,
            string apellido,
            string apodo,
            DateTime fechaIngreso,
            int legajo,
            DateTime fechaNac) : base(nombre, apellido, fechaIngreso, legajo, fechaNac)
        {
            if (legajo <= 0) throw new ArgumentException("El legajo debe ser mayor o igual a cero.");

            _apodo = apodo;
        }

        public override string GetNombreCompleto()
        {
            return $"Bedel {_apodo}";
        }
    }
}
