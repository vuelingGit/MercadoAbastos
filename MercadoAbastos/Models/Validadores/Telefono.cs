using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


namespace MercadoAbastos.Models.Validadores
{
//    [AttributeUsage(AttributeTargets.Field)]
    public class Telefono : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            String dniIntroducido = (String)value;
            string ExpresionRegular = @"^\s*((\(\s*\+?\s*\d{1,4}\s*\))|(\+?\s*\d{1,4}\s*))?([\s-_\.]?[976])([\s-_\.]?\d){8}\s*$";
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