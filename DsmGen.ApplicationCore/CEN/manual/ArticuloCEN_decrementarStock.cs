
using System;
using System.Text;
using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CEN.Dominio_dsm_Articulo_decrementarStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
public partial class ArticuloCEN
{
public void DecrementarStock (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(DsmGen.ApplicationCore.CEN.Dominio_dsm_Articulo_decrementarStock) ENABLED START*/

        // Write here your custom code...
        ArticuloEN en = _IArticuloRepository.ReadOIDDefault (p_oid);

        if (en.Stock < p_cantidad)
                throw new ModelException ("No hay suficiente stock");
        en.Stock -= p_cantidad;
        

            if (en.Stock == 0)
            {
                en.En_stock = false;
            }
            _IArticuloRepository.ModifyDefault(en);

            /*PROTECTED REGION END*/
        }
}
}
