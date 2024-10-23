
using System;
// Definición clase CarritoEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class CarritoEN
{
/**
 *	Atributo usuario
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulo
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo;



/**
 *	Atributo subtotal
 */
private double subtotal;






public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual double Subtotal {
        get { return subtotal; } set { subtotal = value;  }
}





public CarritoEN()
{
        articulo = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
}



public CarritoEN(int id, DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo, double subtotal
                 )
{
        this.init (Id, usuario, articulo, subtotal);
}


public CarritoEN(CarritoEN carrito)
{
        this.init (carrito.Id, carrito.Usuario, carrito.Articulo, carrito.Subtotal);
}

private void init (int id
                   , DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo, double subtotal)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Articulo = articulo;

        this.Subtotal = subtotal;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CarritoEN t = obj as CarritoEN;
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
