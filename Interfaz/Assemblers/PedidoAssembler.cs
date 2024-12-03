using DsmGen.ApplicationCore.EN.Dominio_dsm;
using Interfaz.Models;
using System.Collections.Generic;

namespace Interfaz.Assemblers
{
    public class PedidoAssembler
    {
        public PedidoViewModel convertirENtoViewModel (PedidoEN pedido) 
        {
            PedidoViewModel pedidoViewModel = new PedidoViewModel();
            pedidoViewModel.Id = pedido.Id;
            pedidoViewModel.Estado = pedido.Estado;
            pedidoViewModel.Fecha = (System.DateTime)pedido.Fecha;
            pedidoViewModel.Entrega_est = (System.DateTime)pedido.Entrega_est;
            pedidoViewModel.Gastos_envio = pedido.Gastos_envio;
            pedidoViewModel.Total = pedido.Total;
            return pedidoViewModel;

        }

        public IList<PedidoViewModel> convertirListENToViewModel(IList<PedidoEN> pedidos)
        {
            IList<PedidoViewModel> pedidosViewModel = new List<PedidoViewModel>();
            foreach (PedidoEN pedido in pedidos)
            {
                pedidosViewModel.Add(convertirENtoViewModel(pedido));
            }
            return pedidosViewModel;
        }
    }
}
