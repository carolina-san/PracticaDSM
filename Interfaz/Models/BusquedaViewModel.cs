using DsmGen.ApplicationCore.Enumerated.Dominio_dsm;

namespace Interfaz.Models
{
    public class BusquedaViewModel
    {
        public string Nombre { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public decimal? PrecioMin { get; set; }
        public decimal? PrecioMax { get; set; }
        public Talla_artEnum? Talla { get; set; }
    }
}
