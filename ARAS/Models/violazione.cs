using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ARAS.Models
{
    public class violazione
    {
        public int IDviolazioine { get; set; }
        [Display (Name = "Tipo di violazione")]
        public string DescrizioineViolenza { get; set; }
    }

}