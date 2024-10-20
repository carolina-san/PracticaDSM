

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class Usuario_adminCEN
 *
 */
public partial class Usuario_adminCEN
{
private IUsuario_adminRepository _IUsuario_adminRepository;

public Usuario_adminCEN(IUsuario_adminRepository _IUsuario_adminRepository)
{
        this._IUsuario_adminRepository = _IUsuario_adminRepository;
}

public IUsuario_adminRepository get_IUsuario_adminRepository ()
{
        return this._IUsuario_adminRepository;
}

public void Modificar (string p_Usuario_admin_OID, string p_nombre, Nullable<DateTime> p_fechaNac, String p_pass, string p_nombreSocio)
{
        Usuario_adminEN usuario_adminEN = null;

        //Initialized Usuario_adminEN
        usuario_adminEN = new Usuario_adminEN ();
        usuario_adminEN.Email = p_Usuario_admin_OID;
        usuario_adminEN.Nombre = p_nombre;
        usuario_adminEN.FechaNac = p_fechaNac;
        usuario_adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuario_adminEN.NombreSocio = p_nombreSocio;
        //Call to Usuario_adminRepository

        _IUsuario_adminRepository.Modificar (usuario_adminEN);
}

public void Eliminar (string email
                      )
{
        _IUsuario_adminRepository.Eliminar (email);
}
}
}
