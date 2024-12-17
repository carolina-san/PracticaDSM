using System;

namespace Interfaz.Models
{
    public class ResenyaViewModel
    {
        public int Id { get; set; }  // Identificador de la reseña
        public int Estrellas { get; set; }  // Cantidad de estrellas
        public string Comentario { get; set; }  // Texto del comentario
        public DateTime? Fecha { get; set; }  // Fecha del comentario
        public string Usuario { get; set; }
    }
}
