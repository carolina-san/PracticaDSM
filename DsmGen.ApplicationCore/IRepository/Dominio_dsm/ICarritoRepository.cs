
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface ICarritoRepository
{
void setSessionCP (GenericSessionCP session);

CarritoEN ReadOIDDefault (int id
                          );

void ModifyDefault (CarritoEN carrito);

System.Collections.Generic.IList<CarritoEN> ReadAllDefault (int first, int size);



CarritoEN ReadOID (int id
                   );


int Nuevo (CarritoEN carrito);

void AddArticulo (int p_Carrito_OID, System.Collections.Generic.IList<int> p_articulo_OIDs);
        void EliminarArticulo(int p_Carrito_OID, System.Collections.Generic.IList<int> p_articulo_OIDs);
    }
}
