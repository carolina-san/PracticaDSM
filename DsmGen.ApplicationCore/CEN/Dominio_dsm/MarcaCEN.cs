

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class MarcaCEN
 *
 */
public partial class MarcaCEN
{
private IMarcaRepository _IMarcaRepository;

public MarcaCEN(IMarcaRepository _IMarcaRepository)
{
        this._IMarcaRepository = _IMarcaRepository;
}

public IMarcaRepository get_IMarcaRepository ()
{
        return this._IMarcaRepository;
}

public string Nuevo (string p_nombre)
{
        MarcaEN marcaEN = null;
        string oid;

        //Initialized MarcaEN
        marcaEN = new MarcaEN ();
        marcaEN.Nombre = p_nombre;



        oid = _IMarcaRepository.Nuevo (marcaEN);
        return oid;
}

public void Modificar (string p_Marca_OID)
{
        MarcaEN marcaEN = null;

        //Initialized MarcaEN
        marcaEN = new MarcaEN ();
        marcaEN.Nombre = p_Marca_OID;
        //Call to MarcaRepository

        _IMarcaRepository.Modificar (marcaEN);
}

public void Eliminar (string nombre
                      )
{
        _IMarcaRepository.Eliminar (nombre);
}
        public MarcaEN DameOID(string nombre
                       )
        {
            MarcaEN marcaEN = null;

            marcaEN = _IMarcaRepository.ReadOIDDefault(nombre);
            return marcaEN;
        }


        public System.Collections.Generic.IList<MarcaEN> DameALL (int first, int size)
{
        System.Collections.Generic.IList<MarcaEN> list = null;

        list = _IMarcaRepository.DameALL (first, size);
        return list;
}
public void Seguir (string p_Marca_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        //Call to MarcaRepository

        _IMarcaRepository.Seguir (p_Marca_OID, p_usuario_OIDs);
}
public void NoSeguir (string p_Marca_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        //Call to MarcaRepository

        _IMarcaRepository.NoSeguir (p_Marca_OID, p_usuario_OIDs);
}
}
}
