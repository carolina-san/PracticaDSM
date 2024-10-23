
using System;
// Definición clase MarcaEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class MarcaEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo articulo
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public MarcaEN()
{
        articulo = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
        usuario = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN>();
}



public MarcaEN(string nombre, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario
               )
{
        this.init (Nombre, articulo, usuario);
}


public MarcaEN(MarcaEN marca)
{
        this.init (marca.Nombre, marca.Articulo, marca.Usuario);
}

private void init (string nombre
                   , System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario)
{
        this.Nombre = nombre;


        this.Articulo = articulo;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MarcaEN t = obj as MarcaEN;
        if (t == null)
                return false;
        if (Nombre.Equals (t.Nombre))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nombre.GetHashCode ();
        return hash;
}
}
}
