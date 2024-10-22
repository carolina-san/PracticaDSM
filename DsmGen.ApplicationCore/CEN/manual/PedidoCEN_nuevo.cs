
using System;
using System.Text;
using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;
using DsmGen.ApplicationCore.Enumerated.Dominio_dsm;


/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CEN.Dominio_dsm_Pedido_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
public partial class PedidoCEN
{
public int Nuevo (string p_usuario, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> p_lineaPedido, long p_cod_promocional, float p_gastos_envio, int p_direccion)
{
        /*PROTECTED REGION ID(DsmGen.ApplicationCore.CEN.Dominio_dsm_Pedido_nuevo_customized) START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();

        if (p_usuario != null) {
                pedidoEN.Usuario = new DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN ();
                pedidoEN.Usuario.Email = p_usuario;
        }

        pedidoEN.LineaPedido = p_lineaPedido;

        pedidoEN.Cod_promocional = p_cod_promocional;

        pedidoEN.Gastos_envio = p_gastos_envio;

        pedidoEN.Fecha = DateTime.Now;
        pedidoEN.Estado = EstadoPedidoEnum.pendiente;
            if (p_direccion != -1) {
                pedidoEN.Direccion = new DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN ();
                pedidoEN.Direccion.Id = p_direccion;
        }

        //Call to PedidoRepository

        oid = _IPedidoRepository.Nuevo (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
