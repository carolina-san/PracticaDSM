
using System;
using System.Text;
using System.Collections.Generic;
using DsmGen.ApplicationCore.Exceptions;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


/*PROTECTED REGION ID(usingDsmGen.ApplicationCore.CEN.Dominio_dsm_Usuario_cambiarPass) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
    public partial class UsuarioCEN
    {
        public void CambiarPass(string p_oid, string passAntigua, string passNueva)
        {
            /*PROTECTED REGION ID(DsmGen.ApplicationCore.CEN.Dominio_dsm_Usuario_cambiarPass) ENABLED START*/

            UsuarioEN en = _IUsuarioRepository.DameOID(p_oid);
            string passA = Utils.Util.GetEncondeMD5(passAntigua);
            string passN = Utils.Util.GetEncondeMD5(passNueva);

            if (passA != en.Pass)
            {
                throw new ModelException("La password antigua no coincide");
            }
            else
            {
                if (passN == passA)
                {
                    throw new ModelException("La password nueva no puede ser igual a la antigua");
                }
                else
                {
                    en.Pass = passN;
                    _IUsuarioRepository.Modificar(en);
                }
                /*PROTECTED REGION END*/
            }
        }
    }
}