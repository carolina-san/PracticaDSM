
using System;
using System.Text;
using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CEN.Dominio_dsm_Articulo_mas_stock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
public partial class ArticuloCEN
{
public void Mas_stock (int p_oid, int p_cantidad)
{
            /*PROTECTED REGION ID(DsmGen.ApplicationCore.CEN.Dominio_dsm_Articulo_mas_stock) ENABLED START*/

            // Write here your custom code...

            ArticuloEN en = _IArticuloRepository.ReadOIDDefault(p_oid);
            if (en.En_stock==false)
            {
                en.En_stock = true;
            }

            en.Stock += p_cantidad;


            
            _IArticuloRepository.ModifyDefault(en);

            /*PROTECTED REGION END*/
        }
}
}
