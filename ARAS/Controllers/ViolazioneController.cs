using ARAS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ARAS.Controllers
{
    public class ViolazioneController : Controller
    {
        // GET: Violazione
        public ActionResult listaViolazioni()
        {
            SqlConnection conessione = new SqlConnection();
            List<violazione> violaziones= new List<violazione>();   
          
            try
            {
                conessione.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaDB"].ToString();
                conessione.Open();
                SqlCommand Commando = new SqlCommand();
                Commando.CommandText = "select * from violazione ";
                Commando.Connection = conessione;
                SqlDataReader reader = Commando.ExecuteReader();

                while(reader.Read())
                {
                    violazione V= new violazione(); 
                    V.IDviolazioine = Convert.ToInt32(reader["IDviolazione"]);
                    V.DescrizioineViolenza = reader["Descrizione"].ToString() ;
                    violaziones.Add(V);

                }
            }catch(Exception ex)
            {

            }
            finally { conessione.Close(); } 
            

            return View(violaziones);
        }


        public ActionResult AddViolazione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddViolazione(violazione V)
        {
            List<violazione> ListaViolazioni= new List<violazione>();
            SqlConnection conessione= new SqlConnection();
            try { 
            
            conessione.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaDB"].ToString();
            conessione.Open();
            SqlCommand Commando = new SqlCommand();
            Commando.Connection= conessione;       
            Commando.Parameters.AddWithValue("@descrizione", V.DescrizioineViolenza);
            Commando.CommandText = "insert into violazione values (@descrizione)";
            Commando.Connection = conessione;
            int row = Commando.ExecuteNonQuery();

            if (row > 0)
            {
                ViewBag.statoAzione = "nuovo terroristo si e` inserito con sucesso!";
            }
            } 
            catch(Exception ex ) { }
            finally { conessione.Close(); }

            Thread.Sleep(200);
            return RedirectToAction("listaViolazioni");
        }

        public ActionResult DelViolazione(int id)
        {
            SqlConnection conessione = new SqlConnection();
            try
            {
                conessione.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaDB"].ToString();
                conessione.Open();
                SqlCommand Commando = new SqlCommand();
                Commando.Parameters.AddWithValue("@ID", id);

                Commando.CommandText = "delete from violazione where IDviolazione=@ID";
                Commando.Connection = conessione;
                Commando.ExecuteNonQuery();
            ViewBag.msg = "operazione è andata a buon fine";
            }
            catch (Exception ex)
            {
            ViewBag.msg = $"operazione non è andata a buon fine, errore: {ex.Message}";
          
            }
            finally
            {
                conessione.Close();
            }

            Thread.Sleep(1000);
            return RedirectToAction("listaViolazioni");
        }
    }
}
