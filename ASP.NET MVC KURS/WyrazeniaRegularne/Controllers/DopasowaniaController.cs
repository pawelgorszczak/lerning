using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace WyrazeniaRegularne.Controllers
{
    public class DopasowaniaController : Controller
    {
        //
        // GET: /Dopasowania/

        static List<String> listaWyrazenDoSprawdzenia = new List<string>();
        static List<String> wyrazeniaPasujaceDoWzorca = new List<string>();

        public ActionResult Index(string wzorzec)
        {
            ViewData["ListaWyrazenDoSprawdzenia"] = new MultiSelectList(listaWyrazenDoSprawdzenia, wyrazeniaPasujaceDoWzorca);
            ViewData["Wzorzec"] = wzorzec;
            return View();
        }

        [HttpPost]
        public ActionResult DodajElementDoSprawdzenia(FormCollection form)
        {
            if (form != null)
                listaWyrazenDoSprawdzenia.Add(form["ElementDoSprawdzenia"].ToString());
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult WyczyscListe()
        {
            listaWyrazenDoSprawdzenia.Clear();
            wyrazeniaPasujaceDoWzorca.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SprawdzDopasowania(FormCollection form)
        {
            string wzorzec = form["Wzorzec"].ToString();

            if (listaWyrazenDoSprawdzenia.Count > 0 && !string.IsNullOrEmpty(wzorzec))
            {
                wyrazeniaPasujaceDoWzorca.Clear();

                foreach (var elementListy in listaWyrazenDoSprawdzenia)
                {
                    if (!Regex.IsMatch(elementListy, wzorzec))
                        wyrazeniaPasujaceDoWzorca.Add(elementListy);
                }
            }
            return RedirectToAction("Index", new { wzorzec });
        }
    }
}
