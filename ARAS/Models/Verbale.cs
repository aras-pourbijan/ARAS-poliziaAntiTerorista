using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARAS.Models
{
    public class Verbale
    {
        public int IDverbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrasgrizioneV { get; set; }
        public decimal Importo { get; set; }

        public int DecurtamentoPunti { get; set; }
        public int IDanagrafica { get; set; }
        public int IDViolazione { get; set; }
    }
}