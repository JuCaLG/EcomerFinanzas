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
    
    public partial class Pagos
    {
        public int Id_pago { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
        public int Id_factura { get; set; }
        public int status { get; set; }
        public int precio { get; set; }
        public int Id_pedido { get; set; }
        public int Id_usuario { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Facturas Facturas { get; set; }
        public virtual Pedidos Pedidos { get; set; }
    }
}
