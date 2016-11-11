using System.Xml;

namespace EDeklaracje_WebService.Core
{
    public interface IEdeklaracjeSystemObslugi
    {
        object WyslijDokumentXml(XmlDocument document);
        object PobierzUpoWyslanegoDokumentu(string DocumentId);
    }
}
