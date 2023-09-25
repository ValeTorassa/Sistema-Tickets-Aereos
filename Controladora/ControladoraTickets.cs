using Modelo.Entidades;
using Modelo.Repositorios;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Controladora
{
    public class ControladoraTicketAereo
    {
        private static ControladoraTicketAereo instancia;

        private ControladoraTicketAereo() { }

        public static ControladoraTicketAereo Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraTicketAereo();
                }
                return instancia;
            }
        }

        public ReadOnlyCollection<TicketAereo> RecuperarTicketsAereos()
        {
            try
            {
                return RepositorioTicketAereo.Instancia.RecuperarTicketsAereos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarTicketAereo(TicketAereo ticketAereo)
        {
            try
            {
                var listaTicketsAereos = RepositorioTicketAereo.Instancia.RecuperarTicketsAereos();
                var ticketAereoEncontrado = listaTicketsAereos.FirstOrDefault(x => x.NumeroTicket == ticketAereo.NumeroTicket);
                if (ticketAereoEncontrado == null)
                {
                    var ok = RepositorioTicketAereo.Instancia.Agregar(ticketAereo);
                    if (ok)
                    {
                        return $"El Ticket Aéreo {ticketAereo.NumeroTicket} se agregó correctamente";
                    }
                    else
                    {
                        return $"El Ticket Aéreo {ticketAereo.NumeroTicket} no se ha podido agregar";
                    }
                }
                else
                {
                    return $"El Ticket Aéreo {ticketAereo.NumeroTicket} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarTicketAereo(TicketAereo ticketAereo)
        {
            try
            {
                var listaTicketsAereos = RepositorioTicketAereo.Instancia.RecuperarTicketsAereos();
                var ticketAereoEncontrado = listaTicketsAereos.FirstOrDefault(x => x.NumeroTicket == ticketAereo.NumeroTicket);
                if (ticketAereoEncontrado != null)
                {
                    var ok = RepositorioTicketAereo.Instancia.Eliminar(ticketAereo);
                    if (ok)
                    {
                        return $"El Ticket Aéreo {ticketAereoEncontrado.NumeroTicket} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"El Ticket Aéreo {ticketAereoEncontrado.NumeroTicket} no se ha podido eliminar.";
                    }
                }
                else
                {
                    return $"El Ticket Aéreo con el número {ticketAereo.NumeroTicket} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar eliminar el Ticket Aéreo.";
            }
        }

        public string ModificarTicketAereo(TicketAereo ticketAereo)
        {
            try
            {
                var listaTicketsAereos = RepositorioTicketAereo.Instancia.RecuperarTicketsAereos();
                var ticketAereoEncontrado = listaTicketsAereos.FirstOrDefault(x => x.NumeroTicket == ticketAereo.NumeroTicket);
                if (ticketAereoEncontrado != null)
                {
                    var ok = RepositorioTicketAereo.Instancia.Modificar(ticketAereo);
                    if (ok)
                    {
                        return $"El Ticket Aéreo {ticketAereo.NumeroTicket} se modificó correctamente";
                    }
                    else
                    {
                        return $"El Ticket Aéreo {ticketAereo.NumeroTicket} no se ha podido modificar";
                    }
                }
                else
                {
                    return $"El Ticket Aéreo {ticketAereo.NumeroTicket} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public int AsientosDisponiblesEnAvionFecha(Avion avion, DateTime fecha)
        {
            var todosLosPasajeros = RepositorioTicketAereo.Instancia.ObtenerPasajerosEnAvion(avion);

            var pasajerosEnFecha = todosLosPasajeros.Count(t => t.Avion == avion && t.FechaVuelo.Date == fecha.Date);

            return avion.CapacidadMaxima - pasajerosEnFecha;
        }


        public bool ExisteTicketRepetido(TicketAereo ticket)
        {
            var tickets = RecuperarTicketsAereos();

            return tickets.Any(t => t.FechaVuelo.Date == ticket.FechaVuelo.Date && t.Pasajero.NumeroPasaporte == ticket.Pasajero.NumeroPasaporte);
        }
    }
}
