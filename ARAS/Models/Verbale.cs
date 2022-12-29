using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ARAS.Models
{
    public class Verbale
    {
        public int IDverbale { get; set; }
        [Display(Name = "Data del Violazione")]  
        public DateTime DataViolazione { get; set; }
        [Display(Name = "Indirizzo della violenza")]
        public string IndirizzoViolazione { get; set; }
        [Display(Name = "Nominativo Agente")]
        public string NominativoAgente { get; set; }
        [Display(Name = "Data Trascrizione Verbale")]
        public DateTime DataTrascrizioneV { get; set; }
        [Display(Name = "Importo Della Multa")]
        [DataType(DataType.Currency)]
        public decimal Importo { get; set; }

        [Display(Name = "Decurtamento Punti")]
        public int DecurtamentoPunti { get; set; }
      
        public int IDanagrafica { get; set; }
        public int IDViolazione { get; set; }
    }

}