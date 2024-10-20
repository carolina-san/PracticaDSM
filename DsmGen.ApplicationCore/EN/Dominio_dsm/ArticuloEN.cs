
using System;
// Definición clase ArticuloEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class ArticuloEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo talla
 */
private DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum talla;



/**
 *	Atributo recomendaciones
 */
private string recomendaciones;



/**
 *	Atributo check_verificado
 */
private bool check_verificado;



/**
 *	Atributo desc_verificado
 */
private string desc_verificado;



/**
 *	Atributo foto
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.FotoEN> foto;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido;



/**
 *	Atributo marca
 */
private DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN marca;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo en_stock
 */
private bool en_stock;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum Talla {
        get { return talla; } set { talla = value;  }
}



public virtual string Recomendaciones {
        get { return recomendaciones; } set { recomendaciones = value;  }
}



public virtual bool Check_verificado {
        get { return check_verificado; } set { check_verificado = value;  }
}



public virtual string Desc_verificado {
        get { return desc_verificado; } set { desc_verificado = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.FotoEN> Foto {
        get { return foto; } set { foto = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN Marca {
        get { return marca; } set { marca = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual bool En_stock {
        get { return en_stock; } set { en_stock = value;  }
}





public ArticuloEN()
{
        foto = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.FotoEN>();
        lineaPedido = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN>();
}



public ArticuloEN(int id, string nombre, float precio, string descripcion, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum talla, string recomendaciones, bool check_verificado, string desc_verificado, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.FotoEN> foto, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido, DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN marca, int stock, bool en_stock
                  )
{
        this.init (Id, nombre, precio, descripcion, talla, recomendaciones, check_verificado, desc_verificado, foto, lineaPedido, marca, stock, en_stock);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (articulo.Id, articulo.Nombre, articulo.Precio, articulo.Descripcion, articulo.Talla, articulo.Recomendaciones, articulo.Check_verificado, articulo.Desc_verificado, articulo.Foto, articulo.LineaPedido, articulo.Marca, articulo.Stock, articulo.En_stock);
}

private void init (int id
                   , string nombre, float precio, string descripcion, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum talla, string recomendaciones, bool check_verificado, string desc_verificado, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.FotoEN> foto, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido, DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN marca, int stock, bool en_stock)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Precio = precio;

        this.Descripcion = descripcion;

        this.Talla = talla;

        this.Recomendaciones = recomendaciones;

        this.Check_verificado = check_verificado;

        this.Desc_verificado = desc_verificado;

        this.Foto = foto;

        this.LineaPedido = lineaPedido;

        this.Marca = marca;

        this.Stock = stock;

        this.En_stock = en_stock;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArticuloEN t = obj as ArticuloEN;
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
