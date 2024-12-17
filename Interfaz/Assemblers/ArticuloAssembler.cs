using DsmGen.ApplicationCore.EN.Dominio_dsm;
using Interfaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaz.Assemblers
{
    public class ArticuloAssembler
    {

        public ArticuloViewModel ConvertirENToViewModel(ArticuloEN en)
        {
            ArticuloViewModel art = new ArticuloViewModel();
            art.Id = en.Id;
            art.Nombre = en.Nombre;
            art.Desc_verificado = en.Desc_verificado;
            art.Recomendaciones = en.Recomendaciones;
            art.Check_verificado = en.Check_verificado;
            art.Color = en.Color;
            art.Talla = en.Talla;
            art.Marca = en.Marca;
            art.Descripcion = en.Descripcion;
            art.Precio = en.Precio;
            art.Stock = en.Stock;
            art.Imagen = en.Foto;
            art.Resenyas = new ResenyaAssembler().convertirListENToViewModel(en.Resenya);
            return art;
        }

        public IList<ArticuloViewModel> ConvertirListENToViewModel(IList<ArticuloEN> ens)
        {
            IList<ArticuloViewModel> arts = new List<ArticuloViewModel>();
            foreach (ArticuloEN en in ens)
            {
                arts.Add(ConvertirENToViewModel(en));
            }
            return arts;
        }
    }
}
