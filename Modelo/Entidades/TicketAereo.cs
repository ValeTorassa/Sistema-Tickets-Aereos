using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class TicketAereo
    {
        public int NumeroTicket { get => _numeroTicket; set => _numeroTicket = value; }
        public string Origen { get => _origen; set => _origen = value; }
        public string Destino { get => _destino; set => _destino = value; }
        public Pasajero Pasajero { get => _pasajero; set => _pasajero = value; }
        public Avion Avion { get => _avion; set => _avion = value; }
        public DateTime FechaVuelo { get => _fechaVuelo; set => _fechaVuelo = value; }

        private int _numeroTicket;
        private string _origen;
        private string _destino;
        private Pasajero _pasajero;
        private Avion _avion;
        private DateTime _fechaVuelo;
    }
}
