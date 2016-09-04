using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kadry.Models;

namespace Kadry.Controllers
{
    public class PracownicyController : Controller
    {
        //
        // GET: /Pracownicy/
        static List<Pracownik> listaPracownikow = new List<Pracownik>();


        public ActionResult UtworzPracownika()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UtworzPracownika(Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                listaPracownikow.Add(pracownik);
                return View("ListaPracownikow", listaPracownikow);
            }
            return View(pracownik);
        }

        public ActionResult ListaPracownikow()
        {
            return View(listaPracownikow);
        }
    }
}
