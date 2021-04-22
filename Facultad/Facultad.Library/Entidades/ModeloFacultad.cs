using Facultad.Library.Entidades;
using Facultad.Library.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facultad.Library.Entidades
{
    public class ModeloFacultad
    {
        // ATRIBUTOS
        private List<Alumno> _alumnos;
        private List<Empleado> _empleados;
        private int _cantidadSedes;
        private string _nombre;

        // PROPIEDADES
        public int CantidadSedes => _cantidadSedes;
        public string Nombre => _nombre;

        // MÉTODOS
        public ModeloFacultad(string nombre, int cantidadSedes)
        {
            if (nombre == "")
                throw new ArgumentException("Nombre no puede ser vacío.");

            if (cantidadSedes < 0)
                throw new ArgumentException("La cantidad de sedes no puede ser negativa.");

            _alumnos = new List<Alumno>();
            _empleados = new List<Empleado>();
        }

        public void AgregarAlumno(Alumno alumno)
        {
            if (alumno == null)
                throw new ArgumentNullException();

            foreach(Alumno a in _alumnos)
            {
                if (a.Equals(alumno))
                {
                    throw new AlumnoExistenteException("El alumno ingresado ya es miembro de la facultad");
                }
            }

            _alumnos.Add(alumno);
        }
        public void AgregarAlumno(string nombre, string apellido, int codigo, DateTime fechaNac = new DateTime())
        {
            this.AgregarAlumno(new Alumno(nombre, apellido, codigo, fechaNac));
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException();

            foreach (Empleado e in _empleados)
            {
                if (e.Equals(empleado))
                {
                    throw new EmpleadoExistenteException("El empleado ingresado ya trabaja en la facultad");
                }
            }

            _empleados.Add(empleado);
        }

        public void AgregarBedel(string nombre,
            string apellido,
            string apodo,
            DateTime fechaIngreso,
            int legajo,
            DateTime fechaNac)
        {
            this.AgregarEmpleado(new Bedel(nombre, apellido, apodo, fechaIngreso, legajo, fechaNac));
        }

        public void AgregarDocente(string nombre,
            string apellido,
            DateTime fechaIngreso,
            int legajo,
            DateTime fechaNac)
        {
            this.AgregarEmpleado(new Docente(nombre, apellido, fechaIngreso, legajo, fechaNac));
        }

        public void AgregarDirector(string nombre,
            string apellido,
            DateTime fechaIngreso,
            int legajo,
            DateTime fechaNac)
        {
            this.AgregarEmpleado(new Directivo(nombre, apellido, fechaIngreso, legajo, fechaNac));
        }

        public Alumno BuscarAlumno(int codigo)
        {
            foreach(Alumno a in _alumnos)
            {
                if(a.Codigo == codigo)
                {
                    return a;
                }
            }
            return null;
        }

        public Empleado BuscarEmpleado(int legajo)
        {
            foreach (Empleado e in _empleados)
            {
                if (e.Legajo == legajo)
                {
                    return e;
                }
            }
            return null;
        }

        public bool EliminarAlumno(int codigo)
        {
            Alumno alumno = BuscarAlumno(codigo);
            if(alumno != null)
            {
                return _alumnos.Remove(alumno);
            }
            return false;
        }

        public void EliminarEmpleado(int legajo)
        {
            Empleado empleado = BuscarEmpleado(legajo);
            if (empleado != null)
            {
                _empleados.Remove(empleado);
            }
        }

        public void ModificarEmpleado(Empleado empleado)
        {
            foreach(Empleado e in _empleados)
            {
                if (e.Equals(empleado))
                {
                    e.Nombre = empleado.Nombre;
                    e.Apellido = empleado.Apellido;
                    return;
                }
            }

            throw new EmpleadoNoExisteException($"No existe empleado con el legajo {empleado.Legajo} en la facultad.");
        }

        public List<string> TraerAlumnos()
        {
            List<string> lista = new List<string>();

            foreach(Alumno a in _alumnos)
            {
                lista.Add(a.ToString());
            }

            return lista;
        }

        public List<string> TraerEmpleados()
        {
            List<string> lista = new List<string>();

            foreach (Empleado e in _empleados)
            {
                lista.Add(e.ToString());
            }

            return lista;
        }

        public Empleado TraerEmpleadoPorLegajo(int legajo)
        {
            return BuscarEmpleado(legajo);
        }

        public List<Empleado> TraerEmpleadosPorNombre(string nombre)
        {
            List<Empleado> lista = new List<Empleado>();

            foreach (Empleado e in _empleados)
            {
                if(e.Nombre == nombre)
                {
                    lista.Add(e);
                }
            }

            return lista;
        }
    }
}
