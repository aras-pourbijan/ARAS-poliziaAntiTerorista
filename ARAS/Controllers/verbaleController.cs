using ARAS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARAS.Controllers
{
    public class verbaleController : Controller
    {
        // GET: verbale
        public ActionResult listaVerbale()
        {
            SqlConnection conessione = new SqlConnection();
            List<Verbale> verbali = new List<Verbale>();

            try
            {
                conessione.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaDB"].ToString();
                conessione.Open();
                SqlCommand Commando = new SqlCommand();
                Commando.CommandText = "select IDverbale,Nome,cognome,DataViolazione,DataTrascrizioneVerbale, IndirizzoViolazione ,NominativoAgente,IDviolazione,Importo,DecurtamentoPunti from verbale join ANAGRAFICA on VERBALE.IDanagrafica=ANAGRAFICA.IDanagrafica";
                Commando.Connection = conessione;
                SqlDataReader reader = Commando.ExecuteReader();

                while (reader.Read())
                {
                    Verbale v= new Verbale();
                    v.IDverbale = Convert.ToInt32(reader["IDverbale"]);
                    v.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                    v.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                    v.NominativoAgente = reader["NominativoAgente"].ToString();
                    v.DataTrascrizioneV = Convert.ToDateTime(reader["DataTrascrizioneVerbale"]);
                    v.Importo = Convert.ToDecimal(reader["Importo"]);   
                    v.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                    v.IDViolazione = Convert.ToInt32(reader["IDviolazione"]);
                    
                    verbali.Add(v);

                }
            }
            catch (Exception ex)
            {

            }
            finally { conessione.Close(); }


            return View(verbali);
        }

        public ActionResult InsertVerbale() {
            List<SelectListItem> DdlAnagrafica = new List<SelectListItem>();
            


                return View(); }


    }

 
}