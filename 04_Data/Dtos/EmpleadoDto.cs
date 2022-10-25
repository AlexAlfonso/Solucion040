using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Data.Dtos
{
    public class EmpleadoDto
    {
        public EmpleadoDto(EmpleadoDto entity)
        {
            if (entity == null) return;
            EmployeeID = entity.EmployeeID;
            LastName = entity.LastName;
            FirstName = entity.FirstName;
            birthDate = entity.birthDate;
            Photo = entity.Photo;
            Notes = entity.Notes;
        }

        public EmpleadoDto(Empleado empleado)
        {
        }

        public int EmployeeID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public Nullable<System.DateTime> birthDate { get; set; }

        public string Photo { get; set; }

        public string Notes { get; set; }
        
    }
}
