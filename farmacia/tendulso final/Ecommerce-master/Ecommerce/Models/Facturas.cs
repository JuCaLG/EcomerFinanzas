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
    
    public partial class Facturas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Facturas()
        {
            this.Orden_pago = new HashSet<Orden_pago>();
            this.Pagos = new HashSet<Pagos>();
        }
    
        public int Id_factura { get; set; }
        public int Id_proveedor { get; set; }
        public int Id_pedido { get; set; }
        public Nullable<System.DateTime> fecha_emision { get; set; }
        public Nullable<System.DateTime> fecha_entrega { get; set; }
        public Nullable<double> total_pago { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
    
        public virtual Pedidos Pedidos { get; set; }
        public virtual Provedores Provedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden_pago> Orden_pago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pagos> Pagos { get; set; }
    }
}
