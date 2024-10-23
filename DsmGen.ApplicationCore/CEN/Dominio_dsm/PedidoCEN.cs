

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
public void AddCodigo (int p_Pedido_OID, string p_codigo_promocional_OID)
{
        //Call to PedidoRepository

        _IPedidoRepository.AddCodigo (p_Pedido_OID, p_codigo_promocional_OID);
}
}
}
