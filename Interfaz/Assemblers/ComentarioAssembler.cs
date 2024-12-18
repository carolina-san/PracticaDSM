using DsmGen.ApplicationCore.EN.Dominio_dsm;
using Interfaz.Models;

namespace Interfaz.Assemblers
{
    public class ComentarioAssembler
    {
        public ComentarioViewModel ConvertirENToViewModel(ResenyaEN en)
        {
            ComentarioViewModel coment = new ComentarioViewModel();
            coment.Estrellas = en.Estrellas;
            coment.Articulo = en.Articulo.Id;
            coment.Usuario = en.Usuario.Email;
            coment.Fecha = en.Fecha;
            coment.Comentario = en.Comentario;

            return coment;
        }
    }
}
