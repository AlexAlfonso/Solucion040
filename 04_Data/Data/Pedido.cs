
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace _04_Data.Data
{

using System;
    using System.Collections.Generic;
    
public partial class Pedido
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Pedido()
    {

        this.DetallePedido = new HashSet<DetallePedido>();

    }


    public int OrderID { get; set; }

    public Nullable<int> CustomerID { get; set; }

    public Nullable<int> EmployeeID { get; set; }

    public Nullable<System.DateTime> OrderDate { get; set; }

    public Nullable<int> shipperID { get; set; }



    public virtual Cliente Cliente { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DetallePedido> DetallePedido { get; set; }

    public virtual Empleado Empleado { get; set; }

    public virtual Naviera Naviera { get; set; }

}

}
