
using System;
using System.Text;
using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CEN.Dominio_dsm_Pedido_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
public partial class PedidoCEN
{
public void Modificar (int p_Pedido_OID, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.EstadoPedidoEnum p_estado, Nullable<DateTime> p_entrega_est)
{
        /*PROTECTED REGION ID(DsmGen.ApplicationCore.CEN.Dominio_dsm_Pedido_modificar_customized) START*/

        PedidoEN pedidoEN = null;

            //Initialized PedidoEN
            pedidoEN = new PedidoEN();
            pedidoEN.Id = p_Pedido_OID;
            if (pedidoEN.Estado != p_estado)
            {
                NotificacionEN notificacion = new NotificacionEN(0, "El estado de su pedido ha cambiado a: " + p_estado, pedidoEN.Usuario, pedidoEN);
                Console.WriteLine(notificacion.Texto);
            }
            pedidoEN.Estado = p_estado;
            pedidoEN.Entrega_est = p_entrega_est;
            //Call to PedidoRepository

            _IPedidoRepository.Modificar(pedidoEN);

            /*PROTECTED REGION END*/
        }

        //public void Nuevo(global::Interfaz.Models.LoginUsuarioViewModel user, double v1, int v2)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
