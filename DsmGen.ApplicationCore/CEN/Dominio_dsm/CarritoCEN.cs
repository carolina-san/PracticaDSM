

using System;
using System.Text;
using System.Collections.Generic;

using DsmGen.ApplicationCore.Exceptions;

using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.IRepository.Dominio_dsm;


namespace DsmGen.ApplicationCore.CEN.Dominio_dsm
{
/*
 *      Definition of the class CarritoCEN
 *
 */
public partial class CarritoCEN
{
private ICarritoRepository _ICarritoRepository;

public CarritoCEN(ICarritoRepository _ICarritoRepository)
{
        this._ICarritoRepository = _ICarritoRepository;
}

public ICarritoRepository get_ICarritoRepository ()
{
        return this._ICarritoRepository;
}

public CarritoEN ReadOID (int id
                          )
{
        CarritoEN carritoEN = null;

        carritoEN = _ICarritoRepository.ReadOID (id);
        return carritoEN;
}

public int Nuevo (string p_usuario, double p_subtotal)
{
        CarritoEN carritoEN = null;
        int oid;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                carritoEN.Usuario = new DsmGen.ApplicationCore.EN.Dominio_dsm.UsuarioEN ();
                carritoEN.Usuario.Email = p_usuario;
        }

        carritoEN.Subtotal = p_subtotal;



        oid = _ICarritoRepository.Nuevo (carritoEN);
        return oid;
}

public void AddArticulo (int p_Carrito_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
{
        //Call to CarritoRepository

        _ICarritoRepository.AddArticulo (p_Carrito_OID, p_articulo_OIDs);
}
}
}
