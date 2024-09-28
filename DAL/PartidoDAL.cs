using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class PartidoDAL
    {
        private readonly ConexionDB _conexionDB;

        public PartidoDAL()
        {
            _conexionDB = new ConexionDB();
        }

        public void AgregarPartido(int idDeporte, string equipoLocal, string equipoVisitante, DateTime fechaPartido)
        {
            string query = "INSERT INTO Partido (ID_DEPORTE, EQUIPO_LOCAL, EQUIPO_VISITANTE, FECHA_PARTIDO) " +
                           "VALUES (@ID_DEPORTE, @EQUIPO_LOCAL, @EQUIPO_VISITANTE, @FECHA_PARTIDO)";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_DEPORTE", idDeporte);
                        cmd.Parameters.AddWithValue("@EQUIPO_LOCAL", equipoLocal);
                        cmd.Parameters.AddWithValue("@EQUIPO_VISITANTE", equipoVisitante);
                        cmd.Parameters.AddWithValue("@FECHA_PARTIDO", fechaPartido);

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

        public List<Partido> ObtenerTodosLosPartidos()
        {
            List<Partido> listaPartidos = new List<Partido>();
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
                                Partido partido = new Partido
                                {
                                    IdPartido = (int)reader["ID_PARTIDO"],
                                    IdDeporte = (int)reader["ID_DEPORTE"],
                                    EquipoLocal = reader["EQUIPO_LOCAL"].ToString(),
                                    EquipoVisitante = reader["EQUIPO_VISITANTE"].ToString(),
                                    FechaPartido = (DateTime)reader["FECHA_PARTIDO"],
                                    FechaRegistro = (DateTime)reader["FECHA_REGISTRO"], 
                                    MarcadorLocal = (int)reader["MARCADOR_LOCAL"],
                                    MarcadorVisitante = (int)reader["MARCADOR_VISITANTE"]
                                };
                                listaPartidos.Add(partido);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los partidos: " + ex.Message);
            }

            return listaPartidos;
        }

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

        public Partido ObtenerPartidoPorId(int idPartido)
        {
            Partido partido = null;
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
                                partido = new Partido
                                {
                                    IdPartido = (int)reader["ID_PARTIDO"],
                                    IdDeporte = (int)reader["ID_DEPORTE"],
                                    EquipoLocal = reader["EQUIPO_LOCAL"].ToString(),
                                    EquipoVisitante = reader["EQUIPO_VISITANTE"].ToString(),
                                    FechaPartido = (DateTime)reader["FECHA_PARTIDO"],
                                    MarcadorLocal = (int)reader["MARCADOR_LOCAL"],
                                    MarcadorVisitante = (int)reader["MARCADOR_VISITANTE"]
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el partido: " + ex.Message);
            }

            return partido;
        }

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
                                Deporte deporte = new Deporte
                                {
                                    IdDeporte = (int)reader["ID_DEPORTE"],
                                    Descripcion = reader["DESCRIPCION"].ToString()
                                };
                                deportes.Add(deporte);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los deportes: " + ex.Message);
            }

            return deportes;
        }
    }
}
