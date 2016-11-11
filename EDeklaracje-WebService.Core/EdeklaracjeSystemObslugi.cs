using System;
using System.Text;
using System.Xml;
using EDeklaracje_WebService.Core.BramkaWebReference;

namespace EDeklaracje_WebService.Core
{
    public class EdeklaracjeSystemObslugi : IEdeklaracjeSystemObslugi
    {
        private readonly UslugiUBD _ubcPolaczenie;
        public EdeklaracjeSystemObslugi()
        {
            _ubcPolaczenie = new UslugiUBD();
            
        }
        public object WyslijDokumentXml(XmlDocument document)
        {
            //rozne pliki wsdl - test bramka od zwyklej bramki rozni sie
            DokumentPytanie tempDokuent = new DokumentPytanie() { Dokument = Encoding.Default.GetBytes(document.OuterXml) };
            return null; //_ubcPolaczenie.WyslijDokument(tempDokuent);
        }

        public object PobierzUpoWyslanegoDokumentu(string DocumentId)
        {
            throw new NotImplementedException();
        }
    }
}