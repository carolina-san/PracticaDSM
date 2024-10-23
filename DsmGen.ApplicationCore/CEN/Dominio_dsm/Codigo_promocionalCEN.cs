

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class Codigo_promocionalCEN
 *
 */
public partial class Codigo_promocionalCEN
{
private ICodigo_promocionalRepository _ICodigo_promocionalRepository;

public Codigo_promocionalCEN(ICodigo_promocionalRepository _ICodigo_promocionalRepository)
{
        this._ICodigo_promocionalRepository = _ICodigo_promocionalRepository;
}

public ICodigo_promocionalRepository get_ICodigo_promocionalRepository ()
{
        return this._ICodigo_promocionalRepository;
}

public string Nuevo (string p_id, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.DescuentoEnum p_descuento)
{
        Codigo_promocionalEN codigo_promocionalEN = null;
        string oid;

        //Initialized Codigo_promocionalEN
        codigo_promocionalEN = new Codigo_promocionalEN ();
        codigo_promocionalEN.Id = p_id;

        codigo_promocionalEN.Descuento = p_descuento;



        oid = _ICodigo_promocionalRepository.Nuevo (codigo_promocionalEN);
        return oid;
}

public void Eliminar (string id
                      )
{
        _ICodigo_promocionalRepository.Eliminar (id);
}

public void Modificar (string p_Codigo_promocional_OID, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.DescuentoEnum p_descuento)
{
        Codigo_promocionalEN codigo_promocionalEN = null;

        //Initialized Codigo_promocionalEN
        codigo_promocionalEN = new Codigo_promocionalEN ();
        codigo_promocionalEN.Id = p_Codigo_promocional_OID;
        codigo_promocionalEN.Descuento = p_descuento;
        //Call to Codigo_promocionalRepository

        _ICodigo_promocionalRepository.Modificar (codigo_promocionalEN);
}
}
}
