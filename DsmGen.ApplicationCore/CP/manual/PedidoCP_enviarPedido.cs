
using System;
using System.Text;

using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;
using DsmGen.ApplicationCore.CEN.Dominio_dsm;



/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CP.Dominio_dsm_Pedido_enviarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CP.Dominio_dsm
{
public partial class PedidoCP : GenericBasicCP
{
public void EnviarPedido (int p_oid)
{
        /*PROTECTED REGION ID(DsmGen.ApplicationCore.CP.Dominio_dsm_Pedido_enviarPedido) ENABLED START*/

        PedidoCEN pedidoCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                pedidoCEN = new  PedidoCEN (CPSession.UnitRepo.PedidoRepository);



                // Write here your custom transaction ...


                ArticuloCEN articuloCEN = new ArticuloCEN(CPSession.UnitRepo.ArticuloRepository);
                PedidoEN pedido = pedidoCEN.DameOID(p_oid);
                foreach (LineaPedidoEN linea in pedido.LineaPedido)
                {
                    ArticuloEN articulo = linea.Articulo;
                    articuloCEN.Dec_stock(articulo.Id, linea.Cantidad);
                } 
                pedido.Estado=Enumerated.Dominio_dsm.EstadoPedidoEnum.enviado;
                pedidoCEN.get_IPedidoRepository().Modificar(pedido);


                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
