using DsmGen.ApplicationCore.EN.Dominio_dsm;
using Interfaz.Models;
using System.Collections.Generic;

namespace Interfaz.Assemblers
{
    public class UsuarioAssembler
    {

        public UsuarioViewModel ConvertirENToViewModel (UsuarioEN en)
        {
            UsuarioViewModel usu=new UsuarioViewModel ();
            usu.Email = en.Email;
            usu.Nombre = en.Nombre;
            usu.Password = en.Pass;
            usu.FechaNac = en.FechaNac;

            return usu;
        }
        public IList<UsuarioViewModel> ConvertirListENToViewModel(IList<UsuarioEN> ens)
        {
            IList<UsuarioViewModel> usus = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                usus.Add(ConvertirENToViewModel(en));
            }
            return usus;
        }
    }
}
