
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface IDireccionRepository
{
void setSessionCP (GenericSessionCP session);

DireccionEN ReadOIDDefault (int id
                            );

void ModifyDefault (DireccionEN direccion);

System.Collections.Generic.IList<DireccionEN> ReadAllDefault (int first, int size);



int Nuevo (DireccionEN direccion);

void Modificar (DireccionEN direccion);


void Eliminar (int id
               );


DireccionEN DameOID (int id
                     );


System.Collections.Generic.IList<DireccionEN> DameAll (int first, int size);
}
}
