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
    
    public partial class Pedidos_Productos
    {
        public int Id { get; set; }
        public int Id_Producto { get; set; }
        public int Id_Pedido { get; set; }
        public int Cantidad { get; set; }
        public double Costo { get; set; }
    
        public virtual Productos Productos { get; set; }
        public virtual Pedidos_provedores Pedidos_provedores { get; set; }
    }
}
