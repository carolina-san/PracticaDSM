
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface IBusquedaRepository
{
void setSessionCP (GenericSessionCP session);

BusquedaEN ReadOIDDefault (int id
                           );

void ModifyDefault (BusquedaEN busqueda);

System.Collections.Generic.IList<BusquedaEN> ReadAllDefault (int first, int size);



int Nueva (BusquedaEN busqueda);
}
}
