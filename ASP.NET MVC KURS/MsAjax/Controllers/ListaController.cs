using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MsAjax.Controllers
{
    public class ListaController : Controller
    {
        //
        // GET: /Lista/
        static List<string> listaElementow = new List<string>();
        
        public ActionResult Index(FormCollection formCollection)
        {
            if (formCollection.Count > 0)
                listaElementow.Add(formCollection[0].ToString() + " " + DateTime.Now.ToLongTimeString());

            if(Request.IsAjaxRequest())
                return View("Lista", listaElementow);
            else
                return View();
        }        

    }
}
