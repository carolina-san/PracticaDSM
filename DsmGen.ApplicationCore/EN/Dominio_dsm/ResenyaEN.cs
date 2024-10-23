
using System;
// Definición clase ResenyaEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class ResenyaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estrellas
 */
private int estrellas;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo usuario
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario;



/**
 *	Atributo articulo
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articulo;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Estrellas {
        get { return estrellas; } set { estrellas = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}





public ResenyaEN()
{
}



public ResenyaEN(int id, int estrellas, string comentario, Nullable<DateTime> fecha, DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario, DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articulo
                 )
{
        this.init (Id, estrellas, comentario, fecha, usuario, articulo);
}


public ResenyaEN(ResenyaEN resenya)
{
        this.init (resenya.Id, resenya.Estrellas, resenya.Comentario, resenya.Fecha, resenya.Usuario, resenya.Articulo);
}

private void init (int id
                   , int estrellas, string comentario, Nullable<DateTime> fecha, DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario, DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN articulo)
{
        this.Id = id;


        this.Estrellas = estrellas;

        this.Comentario = comentario;

        this.Fecha = fecha;

        this.Usuario = usuario;

        this.Articulo = articulo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ResenyaEN t = obj as ResenyaEN;
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
