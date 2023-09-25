using Microsoft.Extensions.Configuration;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repositorios
{
    public class RepositorioTicketAereo
    {
        private static RepositorioTicketAereo instancia;
        private List<TicketAereo> ticketsAereos;
        private IConfigurationRoot configuration;

        private RepositorioTicketAereo() 
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            ticketsAereos = new List<TicketAereo>();
            ListarTickets();
        }

        public static RepositorioTicketAereo Instancia
        {
            get 
            { 
                if(instancia == null)
                {
                    instancia = new RepositorioTicketAereo();
                }

                return instancia;
            }
        }


        public ReadOnlyCollection<TicketAereo> RecuperarTicketsAereos()
        {
            try
            {
                return Instancia.ticketsAereos.AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TicketAereo> ObtenerPasajerosEnAvion(Avion avion)
        {
            var PasajerosAvion = ticketsAereos.Where(ticket => ticket.Avion == avion).ToList();

            return PasajerosAvion;
        }

            public bool Agregar(TicketAereo ticket)
        {
            if (AgregarTicket(ticket))
            {
                ticketsAereos.Add(ticket);
                return true;
            }
            return false;
        }


        private bool AgregarTicket(TicketAereo ticket) 
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARTICKETAEREO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                
                command.Parameters.Add("@NumeroTicket", System.Data.SqlDbType.Int).Value = ticket.NumeroTicket;
                command.Parameters.Add("@Origen", System.Data.SqlDbType.NVarChar, 25).Value = ticket.Origen;
                command.Parameters.Add("@Destino", System.Data.SqlDbType.NVarChar, 25).Value = ticket.Destino;
                command.Parameters.Add("@FechaVuelo", System.Data.SqlDbType.DateTime).Value = ticket.FechaVuelo;
                command.Parameters.Add("@NumPasaportePasajero", System.Data.SqlDbType.NVarChar, 25).Value = ticket.Pasajero.NumeroPasaporte;
                command.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.NVarChar, 25).Value = ticket.Avion.Matricula;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            } catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();                              
            } catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }

        public bool Eliminar(TicketAereo ticket)
        {
            if (EliminarTicket(ticket))
            {
                ticketsAereos.Remove(ticket);
                return true;
            }
            return false;
        }

        private bool EliminarTicket(TicketAereo ticket)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARTICKETAEREO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NumeroTicket", System.Data.SqlDbType.Int).Value = ticket.NumeroTicket;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            }catch(SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }catch(Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }


        public bool Modificar(TicketAereo ticket)
        {
            if (ModificarTicket(ticket))
            {
                var TicketModificado = ticketsAereos.FirstOrDefault(t => t.NumeroTicket == ticket.NumeroTicket);
                TicketModificado.Origen = ticket.Origen;
                TicketModificado.Destino = ticket.Destino;
                TicketModificado.Pasajero = ticket.Pasajero;
                TicketModificado.Avion = ticket.Avion;
                TicketModificado.FechaVuelo = ticket.FechaVuelo;
                return true;
            }
            return false;
        }


        private bool ModificarTicket(TicketAereo ticket)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using SqlCommand command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARTICKETAEREO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NumeroTicket", System.Data.SqlDbType.Int).Value = ticket.NumeroTicket;
                command.Parameters.Add("Origen", System.Data.SqlDbType.NVarChar, 50).Value = ticket.Origen;
                command.Parameters.Add("Destino", System.Data.SqlDbType.NVarChar, 50).Value = ticket.Destino;
                command.Parameters.Add("FechaVuelo", System.Data.SqlDbType.DateTime).Value = ticket.FechaVuelo;
                command.Parameters.Add("NumPasaportePasajero", System.Data.SqlDbType.NVarChar, 25).Value = ticket.Pasajero.NumeroPasaporte;
                command.Parameters.Add("MatriculaAvion", System.Data.SqlDbType.NVarChar, 25).Value = ticket.Avion.Matricula;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }

        private void ListarTickets()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_RECUPERARTICKETAEREO ";
                command.Connection = connection;

                connection.Open();

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var ticket = new TicketAereo();
                    ticket.NumeroTicket = (int)(reader["NUMEROTICKET"]);
                    ticket.Origen = reader["ORIGEN"].ToString();
                    ticket.Destino = reader["DESTINO"].ToString();
                    ticket.FechaVuelo = (DateTime)reader["FECHAVUELO"];

                    var numeroPasaporte = reader["NUMEROPASAPORTE"].ToString();
                    var matriculaAvion = reader["MATRICULA"].ToString();
                    
                    ticket.Pasajero = RepositorioPasajero.Instancia.ObtenerPasajero(numeroPasaporte);
                    ticket.Avion = RepositorioAvion.Instancia.ObtenerAvion(matriculaAvion);

                    ticketsAereos.Add(ticket);
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                connection.Close();
                connection.Dispose();
            }
        }

    }
}
