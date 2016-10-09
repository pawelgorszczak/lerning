using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Ankieta.Controllers
{
    public class GlosowaniaController : Controller
    {
        //
        // GET: /Glosowania/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PokazWyniki(FormCollection formCollection)
        {
            DataTable dt = (DataTable)HttpContext.Items["Wyniki"];

            if (formCollection.Count > 0)
            {
                //indexWiersza odpowiada pomniejszonej o 1
                int indexWiersza = Convert.ToInt32(formCollection[0]) - 1;
                int iloscGlosow = Convert.ToInt32(dt.Rows[indexWiersza][1]);

                //Zwiekszam liczbe glosow o 1
                dt.Rows[indexWiersza]["LiczbaGlosow"] = iloscGlosow + 1;

                //Srednia ocena i całkowita liczba głosów
                float srednia = 0.0f;
                int liczbaGlosow = 0, calkowitaLiczbaGlosow = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    liczbaGlosow = Convert.ToInt32(dr["LiczbaGlosow"]);
                    srednia += Convert.ToInt32(dr["Ocena"]) * liczbaGlosow;

                    calkowitaLiczbaGlosow += liczbaGlosow;
                }

                //przekazanie statystyk do widoku
                ViewBag.SredniaOcen = srednia / calkowitaLiczbaGlosow;
                ViewBag.LiczbaGlosow = calkowitaLiczbaGlosow;
            }
            return View(dt);
        }
    }
}
