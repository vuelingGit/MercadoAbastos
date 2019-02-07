using MercadoAbastos.Models.Validadores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercadoAbastos.Models.MetadataParaValidacion
{
    public class ColaboradorAnnotation
    {
        [Required (ErrorMessage = "El DNI es un datos obligatorio")]
        [Key]
        [DNI(ErrorMessage = "Debe de ser un número de DNI válido")]
        [StringLength(9, ErrorMessage = "El DNI debe de tener 9 digitos", MinimumLength = 9)]
        public string DNI { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre debe de tener entre 3 y 100 caracteres", MinimumLength = 3)]
        public string Nombre_Completo { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+")]
        public string Correo_Electronico { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "La contrasela debe de tener al menos 8 caracteres de longitud", MinimumLength = 8)]
        [PasswordFuerte(ErrorMessage = "La contraseña debe de ser fuerte 1 número, 1 minúscula, 1 mayuscula y un simbolo y entre 8 y 16 caracteres")]
        public string Contraseña { get; set; }
    }
}
