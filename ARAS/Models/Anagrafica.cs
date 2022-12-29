using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ARAS.Models
{
    public class Anagrafica
    {
        public int IDanagrafica { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage ="obligatorio")]
        public string Cognome { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "obligatorio")]
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        [Display(Name = "Città")]
        [Required(ErrorMessage = "obligatorio")]
        public string Citta { get; set; }
        [Display(Name = "CAP")]
        public string CAPpostale { get; set; }
        [Display(Name = "Codice Fiscale")]
        [Required(ErrorMessage = "obligatorio")]
        public string CF { get; set; }
    }
}