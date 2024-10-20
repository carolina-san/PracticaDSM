

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public void Modificar (int p_Pedido_OID, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.EstadoPedidoEnum p_estado, Nullable<DateTime> p_fecha, Nullable<DateTime> p_entrega_est, long p_cod_promocional, float p_gastos_envio)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Estado = p_estado;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.Entrega_est = p_entrega_est;
        pedidoEN.Cod_promocional = p_cod_promocional;
        pedidoEN.Gastos_envio = p_gastos_envio;
        //Call to PedidoRepository

        _IPedidoRepository.Modificar (pedidoEN);
}

public void Eliminar (int id
                      )
{
        _IPedidoRepository.Eliminar (id);
}

public PedidoEN DameOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoRepository.DameOID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> DameALL (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoRepository.DameALL (first, size);
        return list;
}
}
}
