

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class DireccionCEN
 *
 */
public partial class DireccionCEN
{
private IDireccionRepository _IDireccionRepository;

public DireccionCEN(IDireccionRepository _IDireccionRepository)
{
        this._IDireccionRepository = _IDireccionRepository;
}

public IDireccionRepository get_IDireccionRepository ()
{
        return this._IDireccionRepository;
}

public int Nuevo (string p_calle, string p_provincia, long p_codPost, long p_telf, string p_nombreCompleto, string p_usuario)
{
        DireccionEN direccionEN = null;
        int oid;

        //Initialized DireccionEN
        direccionEN = new DireccionEN ();
        direccionEN.Calle = p_calle;

        direccionEN.Provincia = p_provincia;

        direccionEN.CodPost = p_codPost;

        direccionEN.Telf = p_telf;

        direccionEN.NombreCompleto = p_nombreCompleto;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                direccionEN.Usuario = new DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN ();
                direccionEN.Usuario.Email = p_usuario;
        }



        oid = _IDireccionRepository.Nuevo (direccionEN);
        return oid;
}

public void Modificar (int p_Direccion_OID, string p_calle, string p_provincia, long p_codPost, long p_telf, string p_nombreCompleto)
{
        DireccionEN direccionEN = null;

        //Initialized DireccionEN
        direccionEN = new DireccionEN ();
        direccionEN.Id = p_Direccion_OID;
        direccionEN.Calle = p_calle;
        direccionEN.Provincia = p_provincia;
        direccionEN.CodPost = p_codPost;
        direccionEN.Telf = p_telf;
        direccionEN.NombreCompleto = p_nombreCompleto;
        //Call to DireccionRepository

        _IDireccionRepository.Modificar (direccionEN);
}

public void Eliminar (int id
                      )
{
        _IDireccionRepository.Eliminar (id);
}

public DireccionEN DameOID (int id
                            )
{
        DireccionEN direccionEN = null;

        direccionEN = _IDireccionRepository.DameOID (id);
        return direccionEN;
}

public System.Collections.Generic.IList<DireccionEN> DameAll (int first, int size)
{
        System.Collections.Generic.IList<DireccionEN> list = null;

        list = _IDireccionRepository.DameAll (first, size);
        return list;
}
}
}
