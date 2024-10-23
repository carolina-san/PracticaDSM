

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class BusquedaCEN
 *
 */
public partial class BusquedaCEN
{
private IBusquedaRepository _IBusquedaRepository;

public BusquedaCEN(IBusquedaRepository _IBusquedaRepository)
{
        this._IBusquedaRepository = _IBusquedaRepository;
}

public IBusquedaRepository get_IBusquedaRepository ()
{
        return this._IBusquedaRepository;
}

public int Nueva (string p_marca, DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum p_talla, double p_precio)
{
        BusquedaEN busquedaEN = null;
        int oid;

        //Initialized BusquedaEN
        busquedaEN = new BusquedaEN ();
        busquedaEN.Marca = p_marca;

        busquedaEN.Talla = p_talla;

        busquedaEN.Precio = p_precio;



        oid = _IBusquedaRepository.Nueva (busquedaEN);
        return oid;
}
}
}
