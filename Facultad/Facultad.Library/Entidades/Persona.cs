using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Entidades
{
    public abstract class Persona
    {
        // ATRIBUTOS
        protected string _apellido;
        protected DateTime _fechaNac;
        protected string _nombre;

        // PROPIEDADES
        public string Apellido
        {
            get => _apellido;
            set => _apellido = value;
        }
        public int Edad { get
            {
                return (DateTime.Today - _fechaNac).Days / 365; // podría mejorarse pensándolo mejor, quizás.
            } }
        public string Nombre { get => _nombre; set => _nombre = value; }

        // MÉTODOS
        protected Persona(string nombre, string apellido, DateTime fechaNacimiento = new DateTime())
        {
            if (nombre == "" || apellido == "")
                throw new ArgumentException("Nombre y Apellido no pueden estar vacíos.");

            _nombre = nombre;
            _apellido = apellido;
            _fechaNac = fechaNacimiento;
        }

        public abstract string GetCredencial();


        public virtual string GetNombreCompleto()
        {
            return $"{_nombre} {_apellido}";
        }

    }
}
