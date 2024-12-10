
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
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido;



        /**
         *	Atributo marca
         */
private string marca;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo en_stock
 */
private bool en_stock;



/**
 *	Atributo resenya
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> resenya;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario;



/**
 *	Atributo usuario_0
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario_0;



/**
 *	Atributo carrito
 */
private System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN> carrito;



/**
 *	Atributo color
 */
private string color;

        /**
         *	Atributo foto
         */
        private string foto;




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

        public virtual string Foto
        {
            get { return foto; }
            set { foto = value; }
        }



        public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual string Marca {
        get { return marca; } set { marca = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual bool En_stock {
        get { return en_stock; } set { en_stock = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> Resenya {
        get { return resenya; } set { resenya = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> Usuario_0 {
        get { return usuario_0; } set { usuario_0 = value;  }
}



public virtual System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN> Carrito {
        get { return carrito; } set { carrito = value;  }
}



public virtual string Color {
        get { return color; } set { color = value;  }
}





public ArticuloEN()
{
        lineaPedido = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN>();
        resenya = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN>();
        usuario = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN>();
        usuario_0 = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN>();
        carrito = new System.Collections.Generic.List<DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN>();
}



public ArticuloEN(int id, string nombre, float precio, string descripcion, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum talla, string recomendaciones, bool check_verificado, string desc_verificado, string foto, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido, string marca, int stock, bool en_stock, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> resenya, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario_0, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN> carrito, string color
                  )
{
        this.init (Id, nombre, precio, descripcion, talla, recomendaciones, check_verificado, desc_verificado, foto, lineaPedido, marca, stock, en_stock, resenya, usuario, usuario_0, carrito, color);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (articulo.Id, articulo.Nombre, articulo.Precio, articulo.Descripcion, articulo.Talla, articulo.Recomendaciones, articulo.Check_verificado, articulo.Desc_verificado, articulo.Foto, articulo.LineaPedido, articulo.Marca, articulo.Stock, articulo.En_stock, articulo.Resenya, articulo.Usuario, articulo.Usuario_0, articulo.Carrito, articulo.Color);
}

private void init (int id
                   , string nombre, float precio, string descripcion, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum talla, string recomendaciones, bool check_verificado, string desc_verificado, string foto, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.LineaPedidoEN> lineaPedido, string marca, int stock, bool en_stock, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> resenya, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN> usuario_0, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN> carrito, string color)
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

        this.Resenya = resenya;

        this.Usuario = usuario;

        this.Usuario_0 = usuario_0;

        this.Carrito = carrito;

        this.Color = color;
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
