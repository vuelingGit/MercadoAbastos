using MercadoAbastos.Models.Validadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadoAbastos.Models.MetadataParaValidacion
{

    public class PuestoAnnotation
    { 
        [Required(ErrorMessage = "Debe de introducir un numero de de puesto")]
        [Range(1, 1000, ErrorMessage = "Debe introducir un numero entre 1 y 1000")]
        [DisplayName("Número dê Puesto")]
        [Key]
        public int Numero_Puesto { get; set; }

        [DisplayName("Imagen")]
        public byte[] Foto { get; set; }

        //ImageMimeType, stores the MIME type for the PhotoFile
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        [DisplayName("Hora Inicio")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> Hora_Entrada { get; set; }

        [DisplayName("Hora Final")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> Hora_Salida { get; set; }

        [MinLength(20, ErrorMessage = "Debe de introducir al menos 20 caracteres en los modos de pago")]
        public string Metodos_de_Pago { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripción { get; set; }

        [Telefono]
        public string Telefono { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string DNI { get; set; }

        [DisplayName("Comentarios")]
        public virtual ICollection<Comentario> Comentario { get; set; }

    }
}