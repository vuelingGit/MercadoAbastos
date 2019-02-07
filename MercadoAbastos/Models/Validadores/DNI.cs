using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


namespace MercadoAbastos.Models.Validadores
{
//    [AttributeUsage(AttributeTargets.Field)]
    public class DNI : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            String dniIntroducido = (String)value;
            string ExpresionRegular = @"^(x?\d{8}|[xyz]\d{7})[trwagmyfpdxbnjzsqvhlcke]$";
            Regex r = new Regex(ExpresionRegular, RegexOptions.IgnoreCase);
            MatchCollection matches = r.Matches(dniIntroducido);
            if (matches.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}