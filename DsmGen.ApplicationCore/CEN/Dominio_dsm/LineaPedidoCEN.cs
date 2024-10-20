

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class LineaPedidoCEN
 *
 */
public partial class LineaPedidoCEN
{
private ILineaPedidoRepository _ILineaPedidoRepository;

public LineaPedidoCEN(ILineaPedidoRepository _ILineaPedidoRepository)
{
        this._ILineaPedidoRepository = _ILineaPedidoRepository;
}

public ILineaPedidoRepository get_ILineaPedidoRepository ()
{
        return this._ILineaPedidoRepository;
}

public int Nuevo (int p_pedido, int p_cantidad, float p_importe, int p_articulo)
{
        LineaPedidoEN lineaPedidoEN = null;
        int oid;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();

        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids num
                lineaPedidoEN.Pedido = new DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN ();
                lineaPedidoEN.Pedido.Id = p_pedido;
        }

        lineaPedidoEN.Cantidad = p_cantidad;

        lineaPedidoEN.Importe = p_importe;


        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids num
                lineaPedidoEN.Articulo = new DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN ();
                lineaPedidoEN.Articulo.Id = p_articulo;
        }



        oid = _ILineaPedidoRepository.Nuevo (lineaPedidoEN);
        return oid;
}

public void Modificar (int p_LineaPedido_OID, int p_cantidad, float p_importe)
{
        LineaPedidoEN lineaPedidoEN = null;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Num = p_LineaPedido_OID;
        lineaPedidoEN.Cantidad = p_cantidad;
        lineaPedidoEN.Importe = p_importe;
        //Call to LineaPedidoRepository

        _ILineaPedidoRepository.Modificar (lineaPedidoEN);
}

public void Eliminar (int num
                      )
{
        _ILineaPedidoRepository.Eliminar (num);
}

public System.Collections.Generic.IList<LineaPedidoEN> DameALL (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> list = null;

        list = _ILineaPedidoRepository.DameALL (first, size);
        return list;
}
}
}
