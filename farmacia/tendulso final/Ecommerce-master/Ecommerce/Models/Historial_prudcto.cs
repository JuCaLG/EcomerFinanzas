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
    
    public partial class Historial_prudcto
    {
        public int Id { get; set; }
        public Nullable<int> Id_producto { get; set; }
        public Nullable<System.DateTime> Fecha_autorizado { get; set; }
        public string Nuevo_precio { get; set; }
        public Nullable<int> Autorizacion { get; set; }
        public string Razon { get; set; }
        public string Observaciones { get; set; }
        public Nullable<System.DateTime> Fecha_Solicita { get; set; }
        public Nullable<double> Anterior_Precio { get; set; }
        public Nullable<int> Descuento { get; set; }
    
        public virtual Productos Productos { get; set; }
    }
}
