using System;
using System.Text;
using System.Xml;
using EDeklaracje_WebService.Core.Web_References.TestBramkaWebReference2;

namespace EDeklaracje_WebService.Core
{
    public class EdeklaracjeSystemOblugiBramkaTestowa : IEdeklaracjeSystemObslugi
    {
        private readonly UslugiUBD _ubcPolaczenie;
        public EdeklaracjeSystemOblugiBramkaTestowa()
        {
            _ubcPolaczenie = new UslugiUBD();
        }
        public object WyslijDokumentXml(XmlDocument document)
        {
            DokumentPytanie tempDokuent = new DokumentPytanie() { Dokument = Encoding.Default.GetBytes(document.OuterXml) };
            return _ubcPolaczenie.WyslijDokument(tempDokuent);
        }

        public object PobierzUpoWyslanegoDokumentu(string DocumentId)
        {
            return _ubcPolaczenie.PobierzUpo(new PobierzUpoPytanie() {NumerReferencyjny = DocumentId});
        }
    }
}