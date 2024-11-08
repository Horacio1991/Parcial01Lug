namespace Entity
{
    public class Partido
    {
        public int IdPartido { get; set; }
        public Deporte Deporte { get; set; }  
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaPartido { get; set; }
        public int MarcadorLocal { get; set; }
        public int MarcadorVisitante { get; set; }
    }
}
