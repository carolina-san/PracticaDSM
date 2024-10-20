
using System;
using System.Text;
using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CEN.Dominio_dsm_Articulo_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
public partial class ArticuloCEN
{
public int Nuevo (string p_nombre, float p_precio, string p_descripcion, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum p_talla, string p_recomendaciones, bool p_check_verificado, string p_desc_verificado, string p_marca, int p_stock)
{
        /*PROTECTED REGION ID(DsmGen.ApplicationCore.CEN.Dominio_dsm_Articulo_nuevo_customized) START*/

        ArticuloEN articuloEN = null;

        int oid;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Nombre = p_nombre;

        articuloEN.Precio = p_precio;

        articuloEN.Descripcion = p_descripcion;

        articuloEN.Talla = p_talla;

        articuloEN.Recomendaciones = p_recomendaciones;

        articuloEN.Check_verificado = p_check_verificado;

        articuloEN.Desc_verificado = p_desc_verificado;


        if (p_marca != null) {
                articuloEN.Marca = new DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN ();
                articuloEN.Marca.Nombre = p_marca;
        }

        articuloEN.Stock = p_stock;

        //Call to ArticuloRepository

        oid = _IArticuloRepository.Nuevo (articuloEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
