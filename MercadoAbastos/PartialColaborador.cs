using MercadoAbastos.Models.MetadataParaValidacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercadoAbastos
{
    [MetadataType(typeof(ColaboradorAnnotation))]
    public partial class Colaborador
    {

    }
}