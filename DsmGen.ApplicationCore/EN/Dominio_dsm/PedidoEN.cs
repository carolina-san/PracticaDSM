
using System;
// Definición clase PedidoEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido;



/**
 *	Atributo estado
 */
private DsmGen.ApplicationCore.Enumerated.Dominio_dsm.EstadoPedidoEnum estado;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo entrega_est
 */
private Nullable<DateTime> entrega_est;



/**
 *	Atributo gastos_envio
 */
private float gastos_envio;



/**
 *	Atributo direccion
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN direccion;



/**
 *	Atributo codigo_promocional
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.Codigo_promocionalEN codigo_promocional;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> notificacion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual DsmGen.ApplicationCore.Enumerated.Dominio_dsm.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual Nullable<DateTime> Entrega_est {
        get { return entrega_est; } set { entrega_est = value;  }
}



public virtual float Gastos_envio {
        get { return gastos_envio; } set { gastos_envio = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.Codigo_promocionalEN Codigo_promocional {
        get { return codigo_promocional; } set { codigo_promocional = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN>();
        notificacion = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN>();
}



public PedidoEN(int id, DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.EstadoPedidoEnum estado, Nullable<DateTime> fecha, Nullable<DateTime> entrega_est, float gastos_envio, DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN direccion, DsmGen.ApplicationCore.EN.Dominio_dsm.Codigo_promocionalEN codigo_promocional, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> notificacion
                )
{
        this.init (Id, usuario, lineaPedido, estado, fecha, entrega_est, gastos_envio, direccion, codigo_promocional, notificacion);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.Id, pedido.Usuario, pedido.LineaPedido, pedido.Estado, pedido.Fecha, pedido.Entrega_est, pedido.Gastos_envio, pedido.Direccion, pedido.Codigo_promocional, pedido.Notificacion);
}

private void init (int id
                   , DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.EstadoPedidoEnum estado, Nullable<DateTime> fecha, Nullable<DateTime> entrega_est, float gastos_envio, DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN direccion, DsmGen.ApplicationCore.EN.Dominio_dsm.Codigo_promocionalEN codigo_promocional, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> notificacion)
{
        this.Id = id;


        this.Usuario = usuario;

        this.LineaPedido = lineaPedido;

        this.Estado = estado;

        this.Fecha = fecha;

        this.Entrega_est = entrega_est;

        this.Gastos_envio = gastos_envio;

        this.Direccion = direccion;

        this.Codigo_promocional = codigo_promocional;

        this.Notificacion = notificacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
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
