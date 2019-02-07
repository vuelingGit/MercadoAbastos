using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadoAbastos.Models.MetadataParaValidacion
{

    public class ComentarioAnnotation
    {
        [Required (ErrorMessage ="Debe de introducir un comentario")]
        [Key]
        [StringLength(10, ErrorMessage = "El Código del comentario debe de tener entre 3 y 10 caracteres", MinimumLength = 3)]
        public string Codigo { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Fecha Creación modificación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy H:mm:ss}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaHoraCreacion { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "El Código del comentario debe de tener entre 20 y 200 caracteres", MinimumLength = 20)]
        public string Contenido { get; set; }

        [Required(ErrorMessage ="Debe de indicar si le gusta o no en el comentario")]
        [DisplayName("¿Te gusto?")]
        public Nullable<bool> Like { get; set; }

        public Nullable<int> Numero_Puesto { get; set; }
        public virtual Puesto Puesto { get; set; }
    }
}