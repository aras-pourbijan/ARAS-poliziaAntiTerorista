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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult infoPartial()
        {


            return View();
        }

        public ActionResult TotalVerbaliByTras()
        {

            string test = "test parzial menu";

            return PartialView("_TotalVerbaliByTras");
        }

       
    }
}