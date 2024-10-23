
using System;
// Definición clase DireccionEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class DireccionEN
{
/**
 *	Atributo calle
 */
private string calle;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo codPost
 */
private long codPost;



/**
 *	Atributo telf
 */
private long telf;



/**
 *	Atributo nombreCompleto
 */
private string nombreCompleto;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario;






public virtual string Calle {
        get { return calle; } set { calle = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual long CodPost {
        get { return codPost; } set { codPost = value;  }
}



public virtual long Telf {
        get { return telf; } set { telf = value;  }
}



public virtual string NombreCompleto {
        get { return nombreCompleto; } set { nombreCompleto = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public DireccionEN()
{
        pedido = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN>();
}



public DireccionEN(int id, string calle, string provincia, long codPost, long telf, string nombreCompleto, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario
                   )
{
        this.init (Id, calle, provincia, codPost, telf, nombreCompleto, pedido, usuario);
}


public DireccionEN(DireccionEN direccion)
{
        this.init (direccion.Id, direccion.Calle, direccion.Provincia, direccion.CodPost, direccion.Telf, direccion.NombreCompleto, direccion.Pedido, direccion.Usuario);
}

private void init (int id
                   , string calle, string provincia, long codPost, long telf, string nombreCompleto, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN usuario)
{
        this.Id = id;


        this.Calle = calle;

        this.Provincia = provincia;

        this.CodPost = codPost;

        this.Telf = telf;

        this.NombreCompleto = nombreCompleto;

        this.Pedido = pedido;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DireccionEN t = obj as DireccionEN;
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
