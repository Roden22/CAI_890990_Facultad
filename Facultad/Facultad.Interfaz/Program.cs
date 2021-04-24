using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolaGenerico;
using Facultad.Library.Entidades;
using Facultad.Library.Excepciones;

namespace Facultad.Interfaz
{
    class Program
    {
        private static bool _salir = false;
        private static ModeloFacultad fac;
        static void Main(string[] args)
        {
            
            string[] claves = { "1", "2", "3", "4", "5", "6", "7", "8" };
            string[] nombres = {
                "Agregar Alumno",
                "Agregar Empleado",
                "EliminarAlumno",
                "EliminarEmpleado",
                "ModificarEmpleado",
                "TraerAlumnos",
                "TraerEmpleados",
                "Salir" 
            };
            Func<bool>[] funciones = { 
                AgregarAlumno,
                AgregarEmpleado,
                EliminarAlumno,
                EliminarEmpleado,
                ModificarEmpleado,
                TraerAlumnos,
                TraerEmpleados,
                Salir 
            };

            try
            {
                Menu menu = new Menu(claves, nombres, funciones);
            

                fac = new ModeloFacultad("FIUBA", 2);

                do
                {
                    menu.Imprimir();
                    try
                    {
                        menu.Elegir();
                    }
                    catch (NotImplementedException e)
                    {
                        Consola.ImprimirError("Función no implementada.");
                    }
                    catch (Exception e)
                    {
                        Consola.ImprimirError(e.Message);
                    }

                    Console.WriteLine();
                } while (_salir == false);

            }
            catch (Exception e)
            {
                Consola.ImprimirError(e.Message);
                Console.WriteLine("\nPresionar tecla para salir...");
                Console.ReadKey();
            }

            //fac.AgregarAlumno("Juan", "Perez", 1, new DateTime(22041991));
            //fac.AgregarAlumno("Pedro", "Gimenez", 2, new DateTime(22041991));

            //List<string> alumnos = fac.TraerAlumnos();
            //ImprimirLista(alumnos);
            //Console.WriteLine("");

            //fac.AgregarBedel("Cacho", "Castaña", "B1", new DateTime(), 1, new DateTime());
            //fac.AgregarDirector("Carlos", "Phalen", new DateTime(), 2, new DateTime());
            //fac.AgregarDocente("Gustavo", "Schneider", new DateTime(), 3, new DateTime());
            //List<string> emps = fac.TraerEmpleados();
            //ImprimirLista(emps);

            //Console.WriteLine("");

            //fac.EliminarAlumno(1);
            //alumnos = fac.TraerAlumnos();
            //ImprimirLista(alumnos);


        }

        private static bool TraerEmpleados()
        {
            ImprimirLista(fac.TraerEmpleados());
            return true;
        }

        private static bool TraerAlumnos()
        {
            ImprimirLista(fac.TraerAlumnos());
            return true;
        }

        private static bool ModificarEmpleado()
        {
            throw new NotImplementedException();
        }

        private static bool EliminarEmpleado()
        {
            int legajo = Consola.LeerInt("legajo", false, false);
            fac.EliminarEmpleado(legajo);
            return true;
        }

        private static bool EliminarAlumno()
        {
            int codigo= Consola.LeerInt("código", false, false);
            fac.EliminarAlumno(codigo);
            return true;
        }

        private static bool AgregarEmpleado()
        {
            string[] claves = { "1", "2", "3", "4" };
            string[] nombres = {
                "Bedel",
                "Docente",
                "Directivo",
                "Salir"
            };
            Func<bool>[] funciones = {
                AgregarBedel,
                AgregarDocente,
                AgregarDirectivo,
                () => false
            };

            Menu menu = new Menu(claves, nombres, funciones);

            menu.Imprimir();
            try
            {
                menu.Elegir();
            }
            catch(Exception e)
            {
                Consola.ImprimirError(e.Message);
                return false;
            }
            return true;
        }

        private static bool AgregarDirectivo()
        {
            string nombre = Consola.LeerString("nombre", false);
            string apellido = Consola.LeerString("apellido", false);
            int legajo = Consola.LeerInt("legajo", false);

            fac.AgregarDirector(nombre, apellido, new DateTime(), legajo, new DateTime());
            return true;
        }

        private static bool AgregarDocente()
        {
            string nombre = Consola.LeerString("nombre", false);
            string apellido = Consola.LeerString("apellido", false);
            int legajo = Consola.LeerInt("legajo", false);

            fac.AgregarDocente(nombre, apellido, new DateTime(), legajo, new DateTime());
            return true;
        }

        private static bool AgregarBedel()
        {
            string nombre = Consola.LeerString("nombre", false);
            string apellido = Consola.LeerString("apellido", false);
            string apodo = Consola.LeerString("apodo", false);
            int legajo = Consola.LeerInt("legajo", false);

            fac.AgregarBedel(nombre, apellido, apodo, new DateTime(), legajo, new DateTime());
            return true;
        }
        private static bool AgregarAlumno()
        {
            string nombre = Consola.LeerString("nombre", false);
            string apellido = Consola.LeerString("apellido", false);
            int codigo = Consola.LeerInt("código", false);

            fac.AgregarAlumno(nombre, apellido, codigo);

            return true;
        }

        static bool Salir()
        {
            _salir = true;
            return true;
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
