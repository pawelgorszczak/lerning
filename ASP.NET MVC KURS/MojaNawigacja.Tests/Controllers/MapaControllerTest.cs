using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MojaNawigacja;
using MojaNawigacja.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MojaNawigacja.Tests.Controllers
{
    [TestClass]
    public class MapaControllerTest
    {
        [TestMethod]
        public void SprawdzMape()
        {
            MapaController mapaController = new MapaController();
            ViewResult viewResult = mapaController.Index() as ViewResult;
            Assert.IsNotNull(viewResult);
        }
    }
}
