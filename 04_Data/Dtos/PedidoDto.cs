using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class PedidoDto
    {
        public PedidoDto(Pedido entity)
        {
            if (entity == null) return;
            OrderID = entity.OrderID;
            OrderDate = entity.OrderDate;
        }
        public int OrderID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
    }
}
