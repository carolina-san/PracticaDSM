
using System;
// Definición clase Usuario_adminEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class Usuario_adminEN                                                                        : DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN


{
/**
 *	Atributo nombreSocio
 */
private string nombreSocio;






public virtual string NombreSocio {
        get { return nombreSocio; } set { nombreSocio = value;  }
}





public Usuario_adminEN() : base ()
{
}



public Usuario_adminEN(string email, string nombreSocio
                       , string nombre, DateTime fechaNac, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, String pass, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> resenya, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN> direccion, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> notificacion, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN> marca, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo_0, DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN carrito
                       )
{
        this.init (Email, nombreSocio, nombre, fechaNac, pedido, pass, resenya, direccion, notificacion, articulo, marca, articulo_0, carrito);
}


public Usuario_adminEN(Usuario_adminEN usuario_admin)
{
        this.init (usuario_admin.Email, usuario_admin.NombreSocio, usuario_admin.Nombre, usuario_admin.FechaNac, usuario_admin.Pedido, usuario_admin.Pass, usuario_admin.Resenya, usuario_admin.Direccion, usuario_admin.Notificacion, usuario_admin.Articulo, usuario_admin.Marca, usuario_admin.Articulo_0, usuario_admin.Carrito);
}

private void init (string email
                   , string nombreSocio, string nombre, DateTime fechaNac, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, String pass, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ResenyaEN> resenya, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.DireccionEN> direccion, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.NotificacionEN> notificacion, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.MarcaEN> marca, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> articulo_0, DsmGen.ApplicationCore.EN.Dominio_dsm.CarritoEN carrito)
{
        this.Email = email;


        this.NombreSocio = nombreSocio;

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
        Usuario_adminEN t = obj as Usuario_adminEN;
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
