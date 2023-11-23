//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Repartidor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Repartidor()
        {
            this.Entregas = new HashSet<Entrega>();
        }
    
        public int IdRepartidor { get; set; }
        public Nullable<int> IdUnidadAsignada { get; set; }
        public string Telefono { get; set; }
        public Nullable<System.DateTime> FechaAIngreso { get; set; }
        public string Fotografia { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrega> Entregas { get; set; }
        public virtual UnidadEntega UnidadEntega { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
