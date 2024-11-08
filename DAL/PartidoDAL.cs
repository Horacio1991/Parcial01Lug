using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
using Mapper;

namespace DAL
{
    public class PartidoDAL
    {
        private readonly ConexionDB _conexionDB;

        public PartidoDAL()
        {
            _conexionDB = new ConexionDB();
        }

        // Agregar un partido a la base de datos
        public void AgregarPartido(Partido partido)
        {
            string query = "INSERT INTO Partido (ID_DEPORTE, EQUIPO_LOCAL, EQUIPO_VISITANTE, FECHA_PARTIDO) " +
                           "VALUES (@ID_DEPORTE, @EQUIPO_LOCAL, @EQUIPO_VISITANTE, @FECHA_PARTIDO)";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_DEPORTE", partido.Deporte.IdDeporte);
                        cmd.Parameters.AddWithValue("@EQUIPO_LOCAL", partido.EquipoLocal);
                        cmd.Parameters.AddWithValue("@EQUIPO_VISITANTE", partido.EquipoVisitante);
                        cmd.Parameters.AddWithValue("@FECHA_PARTIDO", partido.FechaPartido);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al agregar el partido: " + ex.Message);
            }
        }

        // Obtener todos los partidos
        public List<Partido> ObtenerTodosLosPartidos()
        {
            List<Partido> partidos = new List<Partido>();
            string query = "SELECT * FROM Partido";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idDeporte = (int)reader["ID_DEPORTE"];
                                Deporte deporte = ObtenerDeporte(idDeporte);
                                Partido partido = PartidoMapper.Map(reader, deporte);
                                partidos.Add(partido);
                            }
                        }
                    }
                }
                return partidos;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los partidos: " + ex.Message);
            }
        }

        // Obtener un deporte por ID
        private Deporte ObtenerDeporte(int idDeporte)
        {
            string query = "SELECT * FROM Deporte WHERE ID_DEPORTE = @ID_DEPORTE";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_DEPORTE", idDeporte);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return DeporteMapper.Map(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el deporte: " + ex.Message);
            }

            return null;
        }

        // Eliminar un partido por ID
        public void EliminarPartido(int idPartido)
        {
            string query = "DELETE FROM Partido WHERE ID_PARTIDO = @ID_PARTIDO";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_PARTIDO", idPartido);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar el partido: " + ex.Message);
            }
        }

        // Actualizar marcador de un partido
        public void ActualizarMarcador(int idPartido, int marcadorLocal, int marcadorVisitante)
        {
            string query = "UPDATE Partido SET MARCADOR_LOCAL = @MARCADOR_LOCAL, MARCADOR_VISITANTE = @MARCADOR_VISITANTE, " +
                           "FECHA_REGISTRO = GETDATE() " +
                           "WHERE ID_PARTIDO = @ID_PARTIDO AND CONVERT(DATE, FECHA_PARTIDO) = CONVERT(DATE, GETDATE())";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_PARTIDO", idPartido);
                        cmd.Parameters.AddWithValue("@MARCADOR_LOCAL", marcadorLocal);
                        cmd.Parameters.AddWithValue("@MARCADOR_VISITANTE", marcadorVisitante);

                        conn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se puede modificar el marcador de un partido que no se juegue hoy.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar el marcador: " + ex.Message);
            }
        }

        // Obtener un partido por ID
        public Partido ObtenerPartidoPorId(int idPartido)
        {
            string query = "SELECT * FROM Partido WHERE ID_PARTIDO = @ID_PARTIDO";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_PARTIDO", idPartido);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idDeporte = (int)reader["ID_DEPORTE"];
                                Deporte deporte = ObtenerDeporte(idDeporte);
                                return PartidoMapper.Map(reader, deporte);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el partido: " + ex.Message);
            }

            return null;
        }

        // Obtener todos los deportes
        public List<Deporte> ObtenerDeportes()
        {
            List<Deporte> deportes = new List<Deporte>();
            string query = "SELECT * FROM Deporte";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                deportes.Add(DeporteMapper.Map(reader));
                            }
                        }
                    }
                }
                return deportes;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los deportes: " + ex.Message);
            }
        }
    }
}
