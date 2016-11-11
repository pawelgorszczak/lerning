using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EDeklaracje_WebService.Core
{
    public class EdeklaracjeMain
    {
        private IEdeklaracjeSystemObslugi _edeklaracjeSystemObslugi;
        public enum MyEnum
        {
            TestowaBramka=1,ZwyklaBramka=0
        }

        public EdeklaracjeMain(MyEnum wybor)
        {
            if (wybor == MyEnum.TestowaBramka)
            {
                _edeklaracjeSystemObslugi = new EdeklaracjeSystemOblugiBramkaTestowa();
            }
            else
            {
                _edeklaracjeSystemObslugi = new EdeklaracjeSystemObslugi();
            }
        }

        public void ZmienBramke(MyEnum wybor)
        {
            if (wybor == MyEnum.TestowaBramka)
            {
                _edeklaracjeSystemObslugi = new EdeklaracjeSystemOblugiBramkaTestowa();
            }
            else
            {
                _edeklaracjeSystemObslugi = new EdeklaracjeSystemObslugi();
            }
        }

        public object PobierzUpoDokumentu(string refid)
        {
            return _edeklaracjeSystemObslugi.PobierzUpoWyslanegoDokumentu(refid);
        }

        public object WyslijDokument(XmlDocument document)
        {
            return _edeklaracjeSystemObslugi.WyslijDokumentXml(document);
        }

        
    }
}
