using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facultad.Library.Excepciones;

namespace Facultad.Library.Entidades
{
    public class Salario
    {
        // ATRIBUTOS
        private double _bruto;
        private string _codigoTransferencia;
        private double _descuentos;
        private DateTime _fecha;

        // PROPIEDADES
        public double Bruto => _bruto;
        public string CodigoTransferencia => _codigoTransferencia;
        public double Descuentos => _descuentos;
        public DateTime Fecha => _fecha;

        // MÉTODOS
        public Salario(double bruto) 
        {
            // Este constructor sería inconsistente con el que tiene todos los parámetros, pero lo agrego
            // porque está en el diagrama de clases y para simplificar luego.

            _bruto = bruto;
            _codigoTransferencia = "";
            _descuentos = 0;
            _fecha = DateTime.Today;
        }
        public Salario(double bruto, string codigoTransferencia, double descuentos, DateTime fecha)
        {
            if (codigoTransferencia.Equals(string.Empty))
                throw new SalarioInvalidoException("El código de transferencia no puede ser nulo.");

            if( bruto < 0)
                throw new SalarioInvalidoException("El salario bruto debe ser mayor o igual a cero.");

            _bruto = bruto;
            _codigoTransferencia = codigoTransferencia;
            _descuentos = descuentos;
            _fecha = fecha;
        }

        public double GetSalarioNeto()
        {
            return _bruto * 0.83;
        }

    }
}
