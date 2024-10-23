
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface ICodigo_promocionalRepository
{
void setSessionCP (GenericSessionCP session);

Codigo_promocionalEN ReadOIDDefault (string id
                                     );

void ModifyDefault (Codigo_promocionalEN codigo_promocional);

System.Collections.Generic.IList<Codigo_promocionalEN> ReadAllDefault (int first, int size);



string Nuevo (Codigo_promocionalEN codigo_promocional);

void Eliminar (string id
               );


void Modificar (Codigo_promocionalEN codigo_promocional);
}
}
