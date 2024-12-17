using DsmGen.ApplicationCore.EN.Dominio_dsm;
using Interfaz.Models;
using System.Collections.Generic;

namespace Interfaz.Assemblers
{
    public class ResenyaAssembler
    {
        public ResenyaViewModel convertirENtoViewModel(ResenyaEN resenya)
        {
            ResenyaViewModel resenyaViewModel = new ResenyaViewModel();
            resenyaViewModel.Id = resenya.Id;
            resenyaViewModel.Estrellas = resenya.Estrellas;
            resenyaViewModel.Fecha = (System.DateTime)resenya.Fecha;
            resenyaViewModel.Comentario = resenya.Comentario;
            resenyaViewModel.Usuario = resenya.Usuario.Email;
           
            return resenyaViewModel;

        }

        public IList<ResenyaViewModel> convertirListENToViewModel(IList<ResenyaEN> resenyas)
        {
            IList<ResenyaViewModel> resenyasViewModel = new List<ResenyaViewModel>();
            foreach (ResenyaEN resenya in resenyas)
            {
                resenyasViewModel.Add(convertirENtoViewModel(resenya));
            }
            return resenyasViewModel;
        }
    }
}
