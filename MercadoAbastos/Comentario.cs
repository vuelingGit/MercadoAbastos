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
    
    public partial class Comentario
    {
        public string Codigo { get; set; }
        public Nullable<System.DateTime> FechaHoraCreacion { get; set; }
        public string Contenido { get; set; }
        public Nullable<bool> Like { get; set; }
        public Nullable<int> Numero_Puesto { get; set; }
    
        public virtual Puesto Puesto { get; set; }
    }
}