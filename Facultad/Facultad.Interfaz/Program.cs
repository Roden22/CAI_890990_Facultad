using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facultad.Library.Entidades;
using Facultad.Library.Excepciones;

namespace Facultad.Interfaz
{
    class Program
    {
        static void Main(string[] args)
        {
            ModeloFacultad fac = new ModeloFacultad("FIUBA", 2);

            fac.AgregarAlumno("Juan", "Perez", 1, new DateTime(22041991));
            fac.AgregarAlumno("Pedro", "Gimenez", 2, new DateTime(22041991));

            List<string> alumnos = fac.TraerAlumnos();
            ImprimirLista(alumnos);
            Console.WriteLine("");

            fac.AgregarBedel("Cacho", "Castaña", "B1", new DateTime(), 1, new DateTime());
            fac.AgregarDirector("Carlos", "Phalen", new DateTime(), 2, new DateTime());
            fac.AgregarDocente("Gustavo", "Schneider", new DateTime(), 3, new DateTime());
            List<string> emps = fac.TraerEmpleados();
            ImprimirLista(emps);

            Console.WriteLine("");

            fac.EliminarAlumno(1);
            alumnos = fac.TraerAlumnos();
            ImprimirLista(alumnos);

            Console.ReadKey();
        }

        static void ImprimirLista(List<string> lista)
        {
            foreach(string s in lista)
            {
                Console.WriteLine(s);
            }
        }
    }
}
