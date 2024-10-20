
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
private Nullable<DateTime> fechaNac;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido;



/**
 *	Atributo pass
 */
private String pass;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual Nullable<DateTime> FechaNac {
        get { return fechaNac; } set { fechaNac = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public UsuarioEN()
{
        pedido = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN>();
}



public UsuarioEN(string email, string nombre, Nullable<DateTime> fechaNac, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, String pass
                 )
{
        this.init (Email, nombre, fechaNac, pedido, pass);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Email, usuario.Nombre, usuario.FechaNac, usuario.Pedido, usuario.Pass);
}

private void init (string email
                   , string nombre, Nullable<DateTime> fechaNac, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, String pass)
{
        this.Email = email;


        this.Nombre = nombre;

        this.FechaNac = fechaNac;

        this.Pedido = pedido;

        this.Pass = pass;
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
