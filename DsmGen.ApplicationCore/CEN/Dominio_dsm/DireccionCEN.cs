

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

public int Nuevo (string p_calle, string p_provincia, long p_codPost, long p_telf, string p_nombreCompleto)
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



        oid = _IDireccionRepository.Nuevo (direccionEN);
        return oid;
}
}
}
