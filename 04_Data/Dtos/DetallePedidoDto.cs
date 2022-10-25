using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class DetallePedidoDto
    {
        public DetallePedidoDto(DetallePedido entity)
        {
            if (entity == null) return;
            OrderDetailID = entity.OrderDetailID;
            OrderID = entity.OrderID;
            ProductID = entity.ProductID;
            Quantity = entity.Quantity;
        }
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

    }
}
