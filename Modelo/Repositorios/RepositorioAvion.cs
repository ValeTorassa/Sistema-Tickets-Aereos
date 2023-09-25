using Microsoft.Extensions.Configuration;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;

namespace Modelo.Repositorios
{
    public class RepositorioAvion
    {
        private static RepositorioAvion instancia;
        private List<Avion> aviones;
        private IConfigurationRoot configuration;

        private RepositorioAvion()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            aviones = new List<Avion>();
            ListarAviones();
        }

        public static RepositorioAvion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new RepositorioAvion();
                }
                return instancia;
            }
        }

        public ReadOnlyCollection<Avion> RecuperarAviones()
        {
            return aviones.AsReadOnly();
        }

        public Avion ObtenerAvion(string matricula)
        {
            try
            {
                var aviones = RepositorioAvion.Instancia.RecuperarAviones();
                return aviones.FirstOrDefault(avion => avion.Matricula.ToLower() == matricula.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Agregar(Avion avion)
        {
            if (AgregarAvion(avion))
            {
                aviones.Add(avion);
                return true;
            }
            return false;
        }

        private bool AgregarAvion(Avion avion)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARAVION";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@Matricula", System.Data.SqlDbType.NVarChar, 25).Value = avion.Matricula;
                command.Parameters.Add("@Marca", System.Data.SqlDbType.NVarChar, 100).Value = avion.Marca;
                command.Parameters.Add("@Modelo", System.Data.SqlDbType.NVarChar, 100).Value = avion.Modelo;
                command.Parameters.Add("@CapacidadMaxima", System.Data.SqlDbType.Int).Value = avion.CapacidadMaxima;
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

        public bool Eliminar(Avion avion)
        {
            if (EliminarAvion(avion))
            {
                aviones.Remove(avion);
                return true;
            }
            return false;
        }

        private bool EliminarAvion(Avion avion)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARAVIONES";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@Matricula", System.Data.SqlDbType.NVarChar, 25).Value = avion.Matricula;

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

        public bool Modificar(Avion avion)
        {
            if (ModificarAvion(avion))
            {
                var avionModificado = aviones.FirstOrDefault(av => av.Matricula == avion.Matricula);
                avionModificado.Marca = avion.Marca;
                avionModificado.Modelo = avion.Modelo;
                avionModificado.CapacidadMaxima = avion.CapacidadMaxima;
                return true;
            }
            return false;
        }

        private bool ModificarAvion(Avion avion)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARAVIONES";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@Matricula", System.Data.SqlDbType.NVarChar, 25).Value = avion.Matricula;
                command.Parameters.Add("@Marca", System.Data.SqlDbType.NVarChar, 100).Value = avion.Marca;
                command.Parameters.Add("@Modelo", System.Data.SqlDbType.NVarChar, 100).Value = avion.Modelo;
                command.Parameters.Add("@CapacidadMaxima", System.Data.SqlDbType.Int).Value = avion.CapacidadMaxima;

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

        private void ListarAviones()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SP_RECUPERARAVIONES";
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var avion = new Avion();
                        avion.Matricula = reader["MATRICULA"].ToString();
                        avion.Marca = reader["MARCA"].ToString();
                        avion.Modelo = reader["MODELO"].ToString();
                        avion.CapacidadMaxima = Convert.ToInt32(reader["CAPACIDADMAXIMA"].ToString());
                        aviones.Add(avion);
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
