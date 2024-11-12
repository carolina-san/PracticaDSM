
using System;
using System.Text;

using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;
using DsmGen.ApplicationCore.CEN.Dominio_dsm;



/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CP.Dominio_dsm_LineaPedido_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CP.Dominio_dsm
{
public partial class LineaPedidoCP : GenericBasicCP
{
public DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN Nuevo (int p_pedido, int p_cantidad, float p_importe, int p_articulo)
{
        /*PROTECTED REGION ID(DsmGen.ApplicationCore.CP.Dominio_dsm_LineaPedido_nuevo) ENABLED START*/

        LineaPedidoCEN lineaPedidoCEN = null;

        DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                lineaPedidoCEN = new  LineaPedidoCEN (CPSession.UnitRepo.LineaPedidoRepository);




                int oid;
                //Initialized LineaPedidoEN
                LineaPedidoEN lineaPedidoEN;
                lineaPedidoEN = new LineaPedidoEN ();

                if (p_pedido != -1) {
                        lineaPedidoEN.Pedido = new DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN ();
                        lineaPedidoEN.Pedido.Id = p_pedido;
                }

                lineaPedidoEN.Cantidad = p_cantidad;

                lineaPedidoEN.Importe = p_importe;


                if (p_articulo != -1) {
                        lineaPedidoEN.Articulo = new DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN ();
                        lineaPedidoEN.Articulo.Id = p_articulo;
                }
                PedidoCEN pedidocen = new PedidoCEN(CPSession.UnitRepo.PedidoRepository);
                PedidoEN pedido = pedidocen.DameOID(p_pedido);

                ArticuloCEN articulocen = new ArticuloCEN(CPSession.UnitRepo.ArticuloRepository);
                ArticuloEN articulo = articulocen.DameOID(p_articulo);
                pedido.Total+=lineaPedidoEN.Cantidad*articulo.Precio;
                pedidocen.get_IPedidoRepository().Modificar(pedido);


                oid = lineaPedidoCEN.get_ILineaPedidoRepository ().Nuevo (lineaPedidoEN);

                result = lineaPedidoCEN.get_ILineaPedidoRepository ().ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
