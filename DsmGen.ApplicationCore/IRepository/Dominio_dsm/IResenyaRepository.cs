
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface IResenyaRepository
{
void setSessionCP (GenericSessionCP session);

ResenyaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ResenyaEN resenya);

System.Collections.Generic.IList<ResenyaEN> ReadAllDefault (int first, int size);



int Nueva (ResenyaEN resenya);

void Eliminar (int id
               );


ResenyaEN DameOID (int id
                   );


System.Collections.Generic.IList<ResenyaEN> DameAll (int first, int size);
}
}
