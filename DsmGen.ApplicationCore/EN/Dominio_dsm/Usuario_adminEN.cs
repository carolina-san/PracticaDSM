
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
                       , string nombre, Nullable<DateTime> fechaNac, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, String pass
                       )
{
        this.init (Email, nombreSocio, nombre, fechaNac, pedido, pass);
}


public Usuario_adminEN(Usuario_adminEN usuario_admin)
{
        this.init (usuario_admin.Email, usuario_admin.NombreSocio, usuario_admin.Nombre, usuario_admin.FechaNac, usuario_admin.Pedido, usuario_admin.Pass);
}

private void init (string email
                   , string nombreSocio, string nombre, Nullable<DateTime> fechaNac, System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.PedidoEN> pedido, String pass)
{
        this.Email = email;


        this.NombreSocio = nombreSocio;

        this.Nombre = nombre;

        this.FechaNac = fechaNac;

        this.Pedido = pedido;

        this.Pass = pass;
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
