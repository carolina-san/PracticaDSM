
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface IMarcaRepository
{
void setSessionCP (GenericSessionCP session);

MarcaEN ReadOIDDefault (string nombre
                        );

void ModifyDefault (MarcaEN marca);

System.Collections.Generic.IList<MarcaEN> ReadAllDefault (int first, int size);



string Nuevo (MarcaEN marca);

void Modificar (MarcaEN marca);


void Eliminar (string nombre
               );


System.Collections.Generic.IList<MarcaEN> DameALL (int first, int size);


void Seguir (string p_Marca_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void NoSeguir (string p_Marca_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);
}
}
