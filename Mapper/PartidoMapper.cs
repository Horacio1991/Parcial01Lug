using Entity;
using System.Data.SqlClient;

namespace Mapper
{
    public class PartidoMapper
    {
        public static Partido Map(SqlDataReader reader, Deporte deporte)
        {
            return new Partido
            {
                IdPartido = Convert.ToInt32(reader["ID_PARTIDO"]),
                Deporte = deporte,
                EquipoLocal = reader["EQUIPO_LOCAL"].ToString(),
                EquipoVisitante = reader["EQUIPO_VISITANTE"].ToString(),
                FechaPartido = (DateTime)reader["FECHA_PARTIDO"],
                FechaRegistro = (DateTime)reader["FECHA_REGISTRO"],
                MarcadorLocal = Convert.ToInt32(reader["MARCADOR_LOCAL"]),
                MarcadorVisitante = Convert.ToInt32(reader["MARCADOR_VISITANTE"])
            };
        }
    }

   
}
