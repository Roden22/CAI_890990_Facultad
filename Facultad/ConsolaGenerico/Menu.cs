using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaGenerico
{
    public class Menu
    {
        // ATRIBUTOS
        private Dictionary<string, MenuItem> _items;
        private string _titulo = "";

        // PROPIEDADES
        public string Titulo { get => _titulo; set => _titulo = value; }

        // MÉTODOS
        public Menu(string[] claves, string[] nombres, Func<bool>[] funciones, string titulo = "")
        {
            if (claves == null || nombres == null || funciones == null)
                throw new ArgumentNullException("Items de menú no pueden ser null.");

            if (claves.Length != nombres.Length || claves.Length != funciones.Length)
                throw new ArgumentException("Debe haber la misma cantidad de claves, nombres y funciones en un menú.");

            _items = new Dictionary<string, MenuItem>();

            for (int i = 0; i < claves.Length; i++)
            {
                _items.Add(claves[i], new MenuItem(nombres[i], funciones[i]));
            }

            if (titulo == "")
            {
                _titulo = "----------- MENU -----------";
            }
            else
            {
                _titulo = "----------- " + titulo + " -----------";
            }
        }

        public bool Elegir()
        {
            string opcion;
            MenuItem item;

            opcion = Consola.LeerString("opción", false);

            if (!_items.TryGetValue(opcion, out item))
            {
                return false;
            }

            item.Ejecutar();

            return true;
        }
        public void Imprimir()
        {
            Console.WriteLine(_titulo);
            foreach (KeyValuePair<string, MenuItem> item in _items)
            {
                Console.WriteLine($"{item.Key}) {item.Value.Nombre}");
            }
            Console.WriteLine("----------------------------");
        }

    }

    internal class MenuItem
    {
        // ATRIBUTOS
        private string _nombre;
        private Func<bool> _funcion;

        // PROPIEDADES
        public string Nombre { get => _nombre; }
        public Func<bool> Funcion { get => _funcion; }

        // MÉTODOS
        public MenuItem(string nombre, Func<bool> funcion)
        {
            _nombre = nombre;
            _funcion = funcion;
        }

        public bool Ejecutar()
        {
            return _funcion();
        }
    }
}
