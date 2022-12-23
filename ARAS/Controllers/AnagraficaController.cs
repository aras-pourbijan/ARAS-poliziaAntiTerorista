using ARAS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARAS.Controllers
{
    public class AnagraficaController : Controller
    {
        public ActionResult Index()
        {
            List<Anagrafica> ListaAnagrafiche=new List<Anagrafica>();
            SqlConnection conessione = new SqlConnection();
            conessione.Open();
            commando= conessione.



            return View();
        }

        
        public ActionResult listaanagrafica() {




            return View();
        }


    }
}