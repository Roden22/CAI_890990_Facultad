using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Entidades
{
    public abstract class Empleado : Persona
    {
        // ATRIBUTOS
        protected DateTime _fechaIngreso;
        protected int _legajo;
        protected List<Salario> _salarios;

        // PROPIEDADES
        public int Antiguedad => (DateTime.Today - _fechaIngreso).Days; // en días
        public DateTime FechaIngreso => _fechaIngreso;
        public DateTime FechaNacimiento => base._fechaNac;
        public int Legajo => _legajo;
        public Salario UltimoSalario
        {
            get
            {
                if(_salarios.Count == 0)
                {
                    return null;
                }
                else
                {
                    return _salarios.Last();
                }
            }
        }
        


        // MÉTODOS
        public Empleado(string nombre,
            string apellido,
            DateTime fechaIngreso,
            int legajo,
            DateTime fechaNac) : base(nombre, apellido, fechaNac)
        {
            if (legajo <= 0) throw new ArgumentException("El legajo debe ser mayor o igual a cero.");

            _fechaIngreso = fechaIngreso;
            _legajo = legajo;
            _salarios = new List<Salario>();
        }

        public void AgregarSalario(Salario salario)
        {
            if (salario != null)
            {
                _salarios.Add(salario);
            }
            return;
        }

        public override bool Equals(object obj)
        {
            var empleado = obj as Empleado;

            if (empleado == null) 
                return false;

            return this._legajo == empleado._legajo;
        }

        public override string GetCredencial()
        {
            return $"{_legajo} - {GetNombreCompleto()} salario $ {UltimoSalario.GetSalarioNeto()}";
        }


        public override string ToString()
        {
            return GetNombreCompleto();
        }
    }
}
