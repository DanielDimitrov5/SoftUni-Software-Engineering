using System.Threading.Tasks.Dataflow;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class PrisonerExportDTO
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public MessageDTO[] EncryptedMessages { get; set; }
    }

    [XmlType("Message")]
    public class MessageDTO
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}