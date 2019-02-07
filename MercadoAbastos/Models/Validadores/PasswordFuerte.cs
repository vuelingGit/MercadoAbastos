using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


namespace MercadoAbastos.Models.Validadores
{
//    [AttributeUsage(AttributeTargets.Field)]
    public class PasswordFuerte : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            String dniIntroducido = (String)value;
            string ExpresionRegular = @"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,16}$";
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