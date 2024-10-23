
using System;
// Definición clase BusquedaEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class BusquedaEN
{
/**
 *	Atributo marca
 */
private string marca;



/**
 *	Atributo talla
 */
private DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum talla;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulo
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo;






public virtual string Marca {
        get { return marca; } set { marca = value;  }
}



public virtual DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum Talla {
        get { return talla; } set { talla = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}





public BusquedaEN()
{
        articulo = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN>();
}



public BusquedaEN(int id, string marca, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum talla, double precio, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo
                  )
{
        this.init (Id, marca, talla, precio, articulo);
}


public BusquedaEN(BusquedaEN busqueda)
{
        this.init (busqueda.Id, busqueda.Marca, busqueda.Talla, busqueda.Precio, busqueda.Articulo);
}

private void init (int id
                   , string marca, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum talla, double precio, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo)
{
        this.Id = id;


        this.Marca = marca;

        this.Talla = talla;

        this.Precio = precio;

        this.Articulo = articulo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        BusquedaEN t = obj as BusquedaEN;
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
