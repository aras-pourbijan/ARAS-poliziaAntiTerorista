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
    public class AnagraficaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        //create
        [HttpPost]
        public ActionResult Index(Anagrafica A)
        {
            SqlConnection conessione = new SqlConnection();

            try { 
            conessione.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaDB"].ToString();
            conessione.Open();
            SqlCommand Commando = new SqlCommand();
            Commando.Parameters.AddWithValue("@Nome", A.Nome);
            Commando.Parameters.AddWithValue("@Cognome", A.Cognome);
            Commando.Parameters.AddWithValue("@Indirizzo", A.Indirizzo);
            Commando.Parameters.AddWithValue("@citta", A.Citta);
            Commando.Parameters.AddWithValue("@CAP", A.CAPpostale);
            Commando.Parameters.AddWithValue("@CodiceFiscale", A.CF);
            Commando.CommandText = "INSERT INTO anagrafica VALUES (@Cognome , @Nome , @Indirizzo, @citta , @CAP , @CodiceFiscale )";
            Commando.Connection = conessione;
            int row =Commando.ExecuteNonQuery() ;

                if (row > 0)
                {
                    ViewBag.statoAzione = "nuovo terroristo si e` inserito con sucesso!";
                }
            }
            catch(Exception ex)
            {
                ViewBag.errormsg=ex.Message;
            }
            finally { conessione.Close(); }
            Thread.Sleep(2000);
            return RedirectToAction("listaanagrafica");
        }
        //list
        public ActionResult listaanagrafica() {
            List<Anagrafica> ListaAnagrafica = new List<Anagrafica>();
            SqlConnection conessione = new SqlConnection();
            conessione.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaDB"].ToString();
            conessione.Open();
            SqlCommand Commando = conessione.CreateCommand();
            Commando.CommandText = "select * from anagrafica ";
            Commando.Connection = conessione;
            SqlDataReader reader = Commando.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Anagrafica A = new Anagrafica();
                    A.IDanagrafica = Convert.ToInt32(reader["IDanagrafica"]);
                    A.Cognome = reader["Cognome"].ToString().ToUpper();
                    A.Nome = reader["Nome"].ToString().ToUpper();
                    A.Indirizzo = reader["Indirizzo"].ToString();
                    A.Citta = reader["citta"].ToString();
                    A.CAPpostale = reader["CAP"].ToString();
                    A.CF = reader["CodiceFiscale"].ToString();
                    ListaAnagrafica.Add(A);
                }
            }
            catch (Exception ex)
            {

            }
            finally { conessione.Close(); }

            return View(ListaAnagrafica);
        }

        //delete
        public ActionResult DelAnagrafica(int id)
        {

                SqlConnection conessione = new SqlConnection();
            try {
                conessione.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaDB"].ToString();
                conessione.Open();
                SqlCommand Commando = new SqlCommand();
                Commando.Parameters.AddWithValue("@ID", id);

                Commando.CommandText = "delete from anagrafica where IDanagrafica=@ID";
                Commando.Connection = conessione;
                Commando.ExecuteNonQuery(); 
                }
            catch(Exception ex) {
                ViewBag.errmsg=ex.Message;
            }
            finally
            {
                conessione.Close();
            }


            Thread.Sleep(500);
            return RedirectToAction("listaanagrafica");
        }
 
        public ActionResult UpdateTerorista(int id)
        {
            SqlConnection conessione = new SqlConnection();
            conessione.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaDB"].ToString();
            conessione.Open();
            SqlCommand Commando = new SqlCommand();
            Commando.Parameters.AddWithValue("@ID",id)
            Commando.CommandText = "select * from anagrafica where IDanagrafica=@ID";
            Commando.Connection = conessione;
            SqlDataReader reader = Commando.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Anagrafica A = new Anagrafica();
                    A.IDanagrafica = Convert.ToInt32(reader["IDanagrafica"]);
                    A.Cognome = reader["Cognome"].ToString().ToUpper();
                    A.Nome = reader["Nome"].ToString().ToUpper();
                    A.Indirizzo = reader["Indirizzo"].ToString();
                    A.Citta = reader["citta"].ToString();
                    A.CAPpostale = reader["CAP"].ToString();
                    A.CF = reader["CodiceFiscale"].ToString();
                    
                }
            }
            catch (Exception ex)
            {

            }
            finally { conessione.Close(); }

            return View(ListaAnagrafica);


            return View();  
        }

    }


}