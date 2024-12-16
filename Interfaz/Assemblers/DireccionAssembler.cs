using DsmGen.ApplicationCore.EN.Dominio_dsm;
using Interfaz.Models;

namespace Interfaz.Assemblers
{
    public class DireccionAssembler
    {
        public DireccionViewModel ConvertirENToViewModel(DireccionEN en)
        {
            DireccionViewModel dir = new DireccionViewModel();
            dir.Calle = en.Calle;
            dir.Provincia = en.Provincia;
            dir.CodPost = en.CodPost;
            dir.Telefono = en.Telf;
            dir.NombreCompleto = en.NombreCompleto;
            dir.Usuario = en.Usuario.Email;

            return dir;
        }
    }
}
