using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Entidades;
using Modelo.Repositorios;

namespace Controladora
{
    public class ControladoraPasajero
    {
        //singleton       
        private static ControladoraPasajero instancia;

        //constructor privado para que no pueda instanciarse
        private ControladoraPasajero() { }

        //chequea que no haya ninguna instancia de la controladora ya creada
        public static ControladoraPasajero Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraPasajero();
                return instancia;
            }
        }

        public ReadOnlyCollection<Pasajero> RecuperarPasajeros()
        {
            try
            {
                return RepositorioPasajero.Instancia.RecuperarPasajeros();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarPasajero(Pasajero Pasajero)
        {
            try
            {
                var listaPasajero = RepositorioPasajero.Instancia.RecuperarPasajeros();
                var PasajeroEncontrada = listaPasajero.FirstOrDefault(x => x.NumeroPasaporte == Pasajero.NumeroPasaporte);
                if (PasajeroEncontrada == null)
                {
                    var ok = RepositorioPasajero.Instancia.Agregar(Pasajero);
                    if (ok)
                    {
                        return $"La Pasajero {Pasajero.NumeroPasaporte} se agregó correctamente";
                    }
                    else return $"La Pasajero {Pasajero.NumeroPasaporte} no se ha podido agregar";
                }
                else
                {
                    return $"La Pasajero {Pasajero.NumeroPasaporte} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public bool PasajeroTieneTickets(Pasajero pasajero)
        {
            var tickets = RepositorioTicketAereo.Instancia.RecuperarTicketsAereos();

            var ticketsDelPasajero = tickets.FirstOrDefault(x => x.Pasajero.NumeroPasaporte == pasajero.NumeroPasaporte);

            if (ticketsDelPasajero != null)
            {
                return false;
            }

            return true;
        }

        public string EliminarPasajero(Pasajero pasajero)
        {
            try
            {
                var listaPasajeros = RepositorioPasajero.Instancia.RecuperarPasajeros();
                var pasajeroEncontrada = listaPasajeros.FirstOrDefault(x => x.NumeroPasaporte.ToLower() == pasajero.NumeroPasaporte.ToLower());

                var tieneTickets = PasajeroTieneTickets(pasajero);

                if (pasajeroEncontrada != null && tieneTickets)
                {
                    var ok = RepositorioPasajero.Instancia.Eliminar(pasajero);
                    if (ok )
                    {
                        return $"La Pasajero {pasajero.NumeroPasaporte} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"El pasajero {pasajero.NumeroPasaporte} no se ha podido eliminar.";
                    }
                }
                else if (!tieneTickets)
                {
                    return $"El Pasajero {pasajero.NumeroPasaporte} tiene vuelos activos y no se puede eliminar";
                }
                else
                {
                    return $"El Pasajero {pasajero.NumeroPasaporte} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarPasajero(Pasajero pasajero)
        {
            try
            {
                var listaPasajeros = RepositorioPasajero.Instancia.RecuperarPasajeros();
                var PasajeroEncontrada = listaPasajeros.FirstOrDefault(x => x.NumeroPasaporte == pasajero.NumeroPasaporte);
                if (PasajeroEncontrada != null)
                {
                    var ok = RepositorioPasajero.Instancia.Modificar(pasajero);
                    if (ok)
                    {
                        return $"El Pasajero {pasajero.NumeroPasaporte} se modifico correctamentee";
                    }
                    else return $"El Pasajero {pasajero.NumeroPasaporte} no se ha podido modificar";
                }
                else
                {
                    return $"El Pasajero {pasajero.NumeroPasaporte} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

    }
}
