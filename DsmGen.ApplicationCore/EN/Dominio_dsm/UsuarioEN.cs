
using System;
// Definición clase UsuarioEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class UsuarioEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo fechaNac
 */
private DateTime fechaNac;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo resenya
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> resenya;



/**
 *	Atributo direccion
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN> direccion;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> notificacion;



/**
 *	Atributo articulo
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo;



/**
 *	Atributo marca
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN> marca;



/**
 *	Atributo articulo_0
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo_0;



/**
 *	Atributo carrito
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN carrito;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual DateTime FechaNac {
        get { return fechaNac; } set { fechaNac = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> Resenya {
        get { return resenya; } set { resenya = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN> Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN> Marca {
        get { return marca; } set { marca = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> Articulo_0 {
        get { return articulo_0; } set { articulo_0 = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN Carrito {
        get { return carrito; } set { carrito = value;  }
}





public UsuarioEN()
{
        pedido = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN>();
        resenya = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN>();
        direccion = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN>();
        notificacion = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN>();
        articulo = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
        marca = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN>();
        articulo_0 = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
}



public UsuarioEN(string email, string nombre, DateTime fechaNac, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, String pass, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> resenya, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN> direccion, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> notificacion, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN> marca, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo_0, DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN carrito
                 )
{
        this.init (Email, nombre, fechaNac, pedido, pass, resenya, direccion, notificacion, articulo, marca, articulo_0, carrito);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Email, usuario.Nombre, usuario.FechaNac, usuario.Pedido, usuario.Pass, usuario.Resenya, usuario.Direccion, usuario.Notificacion, usuario.Articulo, usuario.Marca, usuario.Articulo_0, usuario.Carrito);
}

private void init (string email
                   , string nombre, DateTime fechaNac, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, String pass, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> resenya, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN> direccion, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> notificacion, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN> marca, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo_0, DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN carrito)
{
        this.Email = email;


        this.Nombre = nombre;

        this.FechaNac = fechaNac;

        this.Pedido = pedido;

        this.Pass = pass;

        this.Resenya = resenya;

        this.Direccion = direccion;

        this.Notificacion = notificacion;

        this.Articulo = articulo;

        this.Marca = marca;

        this.Articulo_0 = articulo_0;

        this.Carrito = carrito;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
