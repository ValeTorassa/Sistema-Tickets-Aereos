using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Pasajero
    {
        public string NumeroPasaporte { get => _numeroPasaporte; set => _numeroPasaporte = value; }
        public string NombreApellido { get => _nombreApellido; set => _nombreApellido = value; }
        public string Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }


        public override string ToString()
        {
            return NombreApellido;
        }

        private string _numeroPasaporte;
        private string _nombreApellido;
        private string _nacionalidad;
        private DateTime _fechaNacimiento;
    }
}
