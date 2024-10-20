
using System;
using System.Text;
using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CEN.Dominio_dsm_Usuario_admin_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
public partial class Usuario_adminCEN
{
public string Nuevo (string p_email, string p_nombre, Nullable<DateTime> p_fechaNac, String p_pass)
{
        /*PROTECTED REGION ID(DsmGen.ApplicationCore.CEN.Dominio_dsm_Usuario_admin_nuevo_customized) START*/

        Usuario_adminEN usuario_adminEN = null;

        string oid;

        //Initialized Usuario_adminEN
        usuario_adminEN = new Usuario_adminEN ();
        usuario_adminEN.Email = p_email;

        usuario_adminEN.Nombre = p_nombre;

        usuario_adminEN.FechaNac = p_fechaNac;

        usuario_adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

            //Call to Usuario_adminRepository
            string[] emailParts = p_email.Split('@');
            string emailPrefix = emailParts[0]; // Parte anterior a la arroba

            // Asignar el nombre de socio con el prefijo "admin_"
            usuario_adminEN.NombreSocio = "admin_" + emailPrefix;
            oid = _IUsuario_adminRepository.Nuevo (usuario_adminEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
