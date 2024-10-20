
using System;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.CP.Dominio_dsm;

namespace DsmGen.ApplicationCore.IRepository.Dominio_dsm
{
public partial interface IPedidoRepository
{
void setSessionCP (GenericSessionCP session);

PedidoEN ReadOIDDefault (int id
                         );

void ModifyDefault (PedidoEN pedido);

System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size);



int Nuevo (PedidoEN pedido);

void Modificar (PedidoEN pedido);


void Eliminar (int id
               );


PedidoEN DameOID (int id
                  );


System.Collections.Generic.IList<PedidoEN> DameALL (int first, int size);
}
}
