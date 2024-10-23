
using System;
// Definición clase Codigo_promocionalEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class Codigo_promocionalEN
{
/**
 *	Atributo id
 */
private string id;



/**
 *	Atributo descuento
 */
private DsmGen.ApplicationCore.Enumerated.Dominio_dsm.DescuentoEnum descuento;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido;






public virtual string Id {
        get { return id; } set { id = value;  }
}



public virtual DsmGen.ApplicationCore.Enumerated.Dominio_dsm.DescuentoEnum Descuento {
        get { return descuento; } set { descuento = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}





public Codigo_promocionalEN()
{
        pedido = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN>();
}



public Codigo_promocionalEN(string id, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.DescuentoEnum descuento, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido
                            )
{
        this.init (Id, descuento, pedido);
}


public Codigo_promocionalEN(Codigo_promocionalEN codigo_promocional)
{
        this.init (codigo_promocional.Id, codigo_promocional.Descuento, codigo_promocional.Pedido);
}

private void init (string id
                   , DsmGen.ApplicationCore.Enumerated.Dominio_dsm.DescuentoEnum descuento, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido)
{
        this.Id = id;


        this.Descuento = descuento;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Codigo_promocionalEN t = obj as Codigo_promocionalEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
