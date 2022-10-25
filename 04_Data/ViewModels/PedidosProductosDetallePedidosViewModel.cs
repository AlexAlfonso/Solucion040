using _04_Data.Data;
using System.Collections.Generic;


namespace _04_Data.ViewModels
{
    public class PedidosProductosDetallePedidosViewModel
    {
        public IList<Pedido> pedidos { get; set; }

        public IList<Producto> productos { get; set; }

        public DetallePedido detallePedido { get; set; }
    }
}
