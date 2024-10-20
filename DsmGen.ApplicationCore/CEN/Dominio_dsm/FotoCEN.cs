

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class FotoCEN
 *
 */
public partial class FotoCEN
{
private IFotoRepository _IFotoRepository;

public FotoCEN(IFotoRepository _IFotoRepository)
{
        this._IFotoRepository = _IFotoRepository;
}

public IFotoRepository get_IFotoRepository ()
{
        return this._IFotoRepository;
}

public int Nuevo (int p_articulo, string p_archivo, string p_alt)
{
        FotoEN fotoEN = null;
        int oid;

        //Initialized FotoEN
        fotoEN = new FotoEN ();

        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids id
                fotoEN.Articulo = new DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN ();
                fotoEN.Articulo.Id = p_articulo;
        }

        fotoEN.Archivo = p_archivo;

        fotoEN.Alt = p_alt;



        oid = _IFotoRepository.Nuevo (fotoEN);
        return oid;
}

public void Modificar (int p_Foto_OID, string p_archivo, string p_alt)
{
        FotoEN fotoEN = null;

        //Initialized FotoEN
        fotoEN = new FotoEN ();
        fotoEN.Id = p_Foto_OID;
        fotoEN.Archivo = p_archivo;
        fotoEN.Alt = p_alt;
        //Call to FotoRepository

        _IFotoRepository.Modificar (fotoEN);
}

public void Eliminar (int id
                      )
{
        _IFotoRepository.Eliminar (id);
}

public FotoEN DameOID (int id
                       )
{
        FotoEN fotoEN = null;

        fotoEN = _IFotoRepository.DameOID (id);
        return fotoEN;
}

public System.Collections.Generic.IList<FotoEN> DameALL (int first, int size)
{
        System.Collections.Generic.IList<FotoEN> list = null;

        list = _IFotoRepository.DameALL (first, size);
        return list;
}
}
}
