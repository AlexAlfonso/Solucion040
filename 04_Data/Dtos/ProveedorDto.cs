using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class ProveedorDto
    {
        public ProveedorDto(Proveedor entity)
        {
            if (entity == null) return;
            supplierID = entity.supplierID;
            supplierName = entity.supplierName;
            ContactName = entity.ContactName;
            Address = entity.Address;
            City = entity.City;
            PostalCode = entity.PostalCode;
            Country = entity.Country;
            Phone = entity.Phone;
        }
        public ProveedorDto()
        {
        }
        public int supplierID { get; set; }

        public string supplierName { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

    }
}
