using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EDeklaracje_WebService;
using EDeklaracje_WebService.Core;
using EDeklaracje_WebService.Core.Web_References.TestBramkaWebReference2;

namespace EDeklaracje_WebService
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var systemx = new EdeklaracjeMain(EdeklaracjeMain.MyEnum.TestowaBramka);
            DokumentOdpowiedz x = (DokumentOdpowiedz)systemx.WyslijDokument(new XmlDocument());
            Console.WriteLine(x.status);
            PobierzUpoOdpowiedz x2 = (PobierzUpoOdpowiedz) systemx.PobierzUpoDokumentu(x.refId);
            Console.WriteLine("status - " + x2.Status + "\n" +"status opis - "+ x2.StatusOpis + "\n" + "Upo - " + x2.Upo);
            Console.ReadLine();
        }
    }
}
