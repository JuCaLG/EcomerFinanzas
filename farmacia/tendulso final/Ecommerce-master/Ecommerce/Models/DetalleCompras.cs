//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleCompras
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int PorcentajeDescuento { get; set; }
        public int PorcentajeIncremnto { get; set; }
        public double SubTotal { get; set; }
        public System.DateTime Fecha_vencimiento { get; set; }
        public Nullable<int> Compras_Id { get; set; }
        public Nullable<int> Productos_Id { get; set; }
    
        public virtual Compras Compras { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
