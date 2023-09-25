using Modelo.Entidades;
using Modelo.Repositorios;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Controladora
{
    public class ControladoraAvion
    {
        private static ControladoraAvion instancia;

        private ControladoraAvion() {}

        public static ControladoraAvion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraAvion();
                }
                return instancia;
            }
        }


        public ReadOnlyCollection<Avion> RecuperarAviones()
        {
            try
            {
                return RepositorioAvion.Instancia.RecuperarAviones();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarAvion(Avion avion)
        {
            try
            {
                var listaAviones = RepositorioAvion.Instancia.RecuperarAviones();
                var avionEncontrado = listaAviones.FirstOrDefault(x => x.Matricula == avion.Matricula);
                if (avionEncontrado == null)
                {
                    var ok = RepositorioAvion.Instancia.Agregar(avion);
                    if (ok)
                    {
                        return $"El Avión {avion.Matricula} se agregó correctamente";
                    }
                    else
                    {
                        return $"El Avión {avion.Matricula} no se ha podido agregar";
                    }
                }
                else
                {
                    return $"El Avión {avion.Matricula} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public bool AvionTieneTickets(Avion avion)
        {
            var tickets = RepositorioTicketAereo.Instancia.RecuperarTicketsAereos();

            var ticketsDelAvion = tickets.FirstOrDefault(ticket => ticket.Avion.Matricula == avion.Matricula);

            if (ticketsDelAvion != null)
            {
                return false;
            }

            return true; ;
        }

        public string EliminarAvion(Avion avion)
        {
            try
            {
                var listaAviones = RepositorioAvion.Instancia.RecuperarAviones();
                var avionEncontrado = listaAviones.FirstOrDefault(x => x.Matricula.ToLower() == avion.Matricula.ToLower());

                var tieneTickets = AvionTieneTickets(avion);

                if (avionEncontrado != null && tieneTickets)
                {
                    var ok = RepositorioAvion.Instancia.Eliminar(avion);
                    if (ok)
                    {
                        return $"El Avión {avionEncontrado.Matricula} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"El Avión {avionEncontrado.Matricula} no se ha podido eliminar.";
                    }
                }
                else if (!tieneTickets)
                {
                    return $"El Avión {avionEncontrado.Matricula} tiene vuelos activos y no se puede eliminar";
                }
                else
                {
                    return $"El Avión con la matrícula {avion.Matricula} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar eliminar el Avión.";
            }
        }

        public string ModificarAvion(Avion avion)
        {
            try
            {
                var listaAviones = RepositorioAvion.Instancia.RecuperarAviones();
                var avionEncontrado = listaAviones.FirstOrDefault(x => x.Matricula == avion.Matricula);
                if (avionEncontrado != null)
                {
                    var ok = RepositorioAvion.Instancia.Modificar(avion);
                    if (ok)
                    {
                        return $"El Avión {avion.Matricula} se modificó correctamente";
                    }
                    else
                    {
                        return $"El Avión {avion.Matricula} no se ha podido modificar";
                    }
                }
                else
                {
                    return $"El Avión {avion.Matricula} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}
