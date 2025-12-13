using SQLite;

namespace EjemplosVarios.Models
{
    public class GrabacionAudio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public DateTime FechaGrabacion { get; set; }
    }
}
