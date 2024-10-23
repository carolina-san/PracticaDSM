

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class ResenyaCEN
 *
 */
public partial class ResenyaCEN
{
private IResenyaRepository _IResenyaRepository;

public ResenyaCEN(IResenyaRepository _IResenyaRepository)
{
        this._IResenyaRepository = _IResenyaRepository;
}

public IResenyaRepository get_IResenyaRepository ()
{
        return this._IResenyaRepository;
}

public int Nueva (int p_estrellas, string p_comentario, Nullable<DateTime> p_fecha, string p_usuario, int p_articulo)
{
        ResenyaEN resenyaEN = null;
        int oid;

        //Initialized ResenyaEN
        resenyaEN = new ResenyaEN ();
        resenyaEN.Estrellas = p_estrellas;

        resenyaEN.Comentario = p_comentario;

        resenyaEN.Fecha = p_fecha;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                resenyaEN.Usuario = new DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN ();
                resenyaEN.Usuario.Email = p_usuario;
        }


        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids id
                resenyaEN.Articulo = new DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN ();
                resenyaEN.Articulo.Id = p_articulo;
        }



        oid = _IResenyaRepository.Nueva (resenyaEN);
        return oid;
}

public void Eliminar (int id
                      )
{
        _IResenyaRepository.Eliminar (id);
}

public ResenyaEN DameOID (int id
                          )
{
        ResenyaEN resenyaEN = null;

        resenyaEN = _IResenyaRepository.DameOID (id);
        return resenyaEN;
}

public System.Collections.Generic.IList<ResenyaEN> DameAll (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> list = null;

        list = _IResenyaRepository.DameAll (first, size);
        return list;
}
}
}
