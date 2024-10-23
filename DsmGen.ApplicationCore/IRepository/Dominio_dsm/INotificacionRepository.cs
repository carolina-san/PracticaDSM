
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface INotificacionRepository
{
void setSessionCP (GenericSessionCP session);

NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int Nueva (NotificacionEN notificacion);

void Eliminar (int id
               );


NotificacionEN DameOID (int id
                        );


System.Collections.Generic.IList<NotificacionEN> DameAll (int first, int size);
}
}
