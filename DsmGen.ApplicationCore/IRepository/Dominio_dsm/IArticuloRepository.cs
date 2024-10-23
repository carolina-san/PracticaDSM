
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface IArticuloRepository
{
void setSessionCP (GenericSessionCP session);

ArticuloEN ReadOIDDefault (int id
                           );

void ModifyDefault (ArticuloEN articulo);

System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size);



ArticuloEN DameOID (int id
                    );


System.Collections.Generic.IList<ArticuloEN> DameALL (int first, int size);


int Nuevo (ArticuloEN articulo);

void Modificar (ArticuloEN articulo);


void Eliminar (int id
               );




void Favorito (int p_Articulo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void NotFavorito (int p_Articulo_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void NotificacionActivada (int p_Articulo_OID, System.Collections.Generic.IList<string> p_usuario_0_OIDs);

void NotificacionDesactivada (int p_Articulo_OID, System.Collections.Generic.IList<string> p_usuario_0_OIDs);

System.Collections.Generic.IList<DsmGen.ApplicationCore.EN.Dominio_dsm.ArticuloEN> DamePorTalla (DsmGen.ApplicationCore.Enumerated.Dominio_dsm.Talla_artEnum ? p_talla);
}
}
