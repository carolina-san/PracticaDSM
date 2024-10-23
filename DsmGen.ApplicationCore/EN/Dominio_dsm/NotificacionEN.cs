
using System;
// Definición clase NotificacionEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo usuario
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario;



/**
 *	Atributo pedido
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN pedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(int id, string texto, DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario, DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN pedido
                      )
{
        this.init (Id, texto, usuario, pedido);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (notificacion.Id, notificacion.Texto, notificacion.Usuario, notificacion.Pedido);
}

private void init (int id
                   , string texto, DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario, DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN pedido)
{
        this.Id = id;


        this.Texto = texto;

        this.Usuario = usuario;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
