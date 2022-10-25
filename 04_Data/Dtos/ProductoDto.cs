using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class ProductoDto
    {
        public ProductoDto(Producto entity)
        {
            if (entity == null) return;
            ProductID = entity.ProductID;
            ProductName = entity.ProductName;
            unit = entity.unit;
            Price = entity.Price;
        }
        public ProductoDto()
        {

        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
    
}
