using Entity;
using System.Data.SqlClient;


namespace Mapper
{
    public class DeporteMapper
    {
        public static Deporte Map(SqlDataReader reader)
        {
            return new Deporte
            {
                IdDeporte = Convert.ToInt32(reader["ID_DEPORTE"]),
                Descripcion = reader["DESCRIPCION"].ToString()
            };
        }
    }
}
