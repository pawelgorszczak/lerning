using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojaNawigacja.Models;

namespace MojaNawigacja.Controllers
{
    public class MapaController : Controller
    {
        //
        // GET: /Mapa/

        public ActionResult Index()
        {
            return View();
        }

        static NawigacjaDatabaseEntities1 entities = new NawigacjaDatabaseEntities1();
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection formularz)
        {
            int idNowejTrasy = 0;
            if (ModelState.IsValid)
            {                

                if (entities.Adresy.Count() > 0)
                    idNowejTrasy = entities.Adresy.Max(x =>x.IdTrasy) + 1;
            

            var nowaTrasa = Adresy.CreateAdresy(idNowejTrasy);
            nowaTrasa.MiejsceWyjazdu = formularz["miejsceWyjazdu"].ToString();
            nowaTrasa.MiejsceDocelowe = formularz["miejsceDocelowe"].ToString();
            nowaTrasa.DataDodania = System.DateTime.Now;

            entities.AddToAdresy(nowaTrasa);
            entities.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

            return View(nowaTrasa);
            }

            return View();
            
        }
        public ActionResult Transfer()
        {
            //Lista cyfr
            List<int> Cyfry = new List<int>();
            for(int i = 0; i<10; i++)
                Cyfry.Add(i);

            //View Data
            ViewData["Imie"] = "Mikołaj";
            ViewData["Nazwisko"] = "Kopernik";
            ViewData["Cyfry"] = Cyfry;

            //ViewBag
            ViewBag.Imie = "Albert";
            ViewBag.Nazwosko = "Einstein";
            ViewBag.Cyfry = Cyfry;


            return View();
        }
        public ActionResult WyswietlTrasy()
        {
            return View("Trasy", entities);
        }

        public ActionResult UsunTrase(Adresy adres)
        {
            if(entities.Adresy.Count()>0)
            {
                var trasaDoUsuniecia = entities.Adresy.Where(s => s.IdTrasy == adres.IdTrasy).First();
                entities.Adresy.DeleteObject(trasaDoUsuniecia);
                entities.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
            }
            return View("Trasy", entities);
        }

    }
}
