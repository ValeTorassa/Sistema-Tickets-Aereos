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
    public class RepositorioPasajero
    {
        private static RepositorioPasajero instancia;
        private List<Pasajero> pasajeros;
        private IConfigurationRoot configuration;

        private RepositorioPasajero()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            pasajeros = new List<Pasajero>();
            Listarpasajeros();
        }

        public static RepositorioPasajero Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new RepositorioPasajero();
                }
                return instancia;
            }
        }

        public ReadOnlyCollection<Pasajero> RecuperarPasajeros()
        {
            return pasajeros.AsReadOnly();
        }

        public Pasajero ObtenerPasajero(string numPasaporte)
        {
            try
            {
                var pasajeros = RepositorioPasajero.Instancia.RecuperarPasajeros();
                return pasajeros.FirstOrDefault(pasajero => pasajero.NumeroPasaporte.ToLower() == numPasaporte.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Agregar(Pasajero pasajero)
        {
            if (Agregarpasajero(pasajero))
            {
                pasajeros.Add(pasajero);
                return true;
            }
            return false;
        }


        private bool Agregarpasajero(Pasajero pasajero)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARPASAJERO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NumeroPasaporte", System.Data.SqlDbType.NVarChar, 25).Value = pasajero.NumeroPasaporte;
                command.Parameters.Add("@NombreApellido", System.Data.SqlDbType.NVarChar, 50).Value = pasajero.NombreApellido;
                command.Parameters.Add("@Nacionalidad", System.Data.SqlDbType.NVarChar, 50).Value = pasajero.Nacionalidad;
                command.Parameters.Add("@FechaDeNacimiento", System.Data.SqlDbType.Date).Value = pasajero.FechaNacimiento;
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


        public bool Eliminar(Pasajero pasajero)
        {
            if (Eliminarpasajero(pasajero))
            {
                pasajeros.Remove(pasajero);
                return true;
            }
            return false;
        }

        private bool Eliminarpasajero(Pasajero pasajero)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARPASAJERO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NumeroPasaporte", System.Data.SqlDbType.NVarChar, 25).Value = pasajero.NumeroPasaporte;

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


        public bool Modificar(Pasajero pasajero)
        {
            if (Modificarpasajero(pasajero))
            {
                var pasajeroModificada = pasajeros.FirstOrDefault(pas => pas.NumeroPasaporte == pasajero.NumeroPasaporte);
                pasajeroModificada.NombreApellido = pasajero.NombreApellido;
                pasajeroModificada.Nacionalidad = pasajero.Nacionalidad;
                pasajeroModificada.FechaNacimiento = pasajero.FechaNacimiento;
                return true;
            }
            return false;
        }

        private bool Modificarpasajero(Pasajero pasajero)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARPASAJERO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NumeroPasaporte", System.Data.SqlDbType.NVarChar, 25).Value = pasajero.NumeroPasaporte;
                command.Parameters.Add("@NombreApellido", System.Data.SqlDbType.NVarChar, 50).Value = pasajero.NombreApellido;
                command.Parameters.Add("@Nacionalidad", System.Data.SqlDbType.NVarChar, 50).Value = pasajero.Nacionalidad;
                command.Parameters.Add("@FechaDeNacimiento", System.Data.SqlDbType.Date).Value = pasajero.FechaNacimiento;

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

        private void Listarpasajeros()
        {

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SP_RECUPERARPASAJEROS";
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var pasajero = new Pasajero();
                        pasajero.NumeroPasaporte = reader["NUMERODEPASAPORTE"].ToString();
                        pasajero.NombreApellido = reader["NOMBREAPELLIDO"].ToString();
                        pasajero.Nacionalidad = reader["NACIONALIDAD"].ToString();
                        pasajero.FechaNacimiento = Convert.ToDateTime(reader["FECHADENACIMIENTO"].ToString());
                        pasajeros.Add(pasajero);
                    }
                    command.Connection.Close();
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
