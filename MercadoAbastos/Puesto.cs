//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MercadoAbastos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Puesto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Puesto()
        {
            this.Comentario = new HashSet<Comentario>();
        }
        public string Nombre { get; set; }
        public int Numero_Puesto { get; set; }
        public byte[] Foto { get; set; }
        public Nullable<System.TimeSpan> Hora_Entrada { get; set; }
        public Nullable<System.TimeSpan> Hora_Salida { get; set; }
        public string Metodos_de_Pago { get; set; }
        public string Descripción { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }
        public string ImageMimeType { get; set; }
    
        public virtual Colaborador Colaborador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario { get; set; }
    }
}
