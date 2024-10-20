
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






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}





public MarcaEN()
{
        articulo = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
}



public MarcaEN(string nombre, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo
               )
{
        this.init (Nombre, articulo);
}


public MarcaEN(MarcaEN marca)
{
        this.init (marca.Nombre, marca.Articulo);
}

private void init (string nombre
                   , System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo)
{
        this.Nombre = nombre;


        this.Articulo = articulo;
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
