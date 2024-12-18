using System;

namespace Interfaz.Models
{
    public class ComentarioViewModel
    {
        public int Estrellas { get; set; }
        public string Comentario { get; set; }
        public int Articulo { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
