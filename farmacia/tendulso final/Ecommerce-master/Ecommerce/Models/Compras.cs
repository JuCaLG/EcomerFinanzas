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
    
    public partial class Compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compras()
        {
            this.DetalleCompras = new HashSet<DetalleCompras>();
        }
    
        public int Id { get; set; }
        public System.DateTime FechaCompra { get; set; }
        public int Status { get; set; }
        public int TipoPago { get; set; }
        public double Total { get; set; }
        public Nullable<int> Provedores_Id { get; set; }
    
        public virtual Provedores Provedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompras> DetalleCompras { get; set; }
    }
}
