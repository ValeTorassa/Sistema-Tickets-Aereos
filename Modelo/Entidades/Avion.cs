using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Avion
    {
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public int CapacidadMaxima { get => _capacidadMaxima; set => _capacidadMaxima = value; }


        public override string ToString()
        {
            return Matricula;
        }

        public int GenerarAsientoAleatorio()
        {
            Random random = new Random();

            int asientoAleatorio = random.Next(1, CapacidadMaxima);

            return asientoAleatorio;
        }

        private string _matricula;
        private string _marca;
        private string _modelo;
        private int _capacidadMaxima;
    }
}
