using System.Xml.Serialization;

namespace XmlSerialization
{

  [XmlRoot("Request")]
  public class Request
  {

    [XmlElement("id")]
    public int Id { get; set; }

    [XmlElement("lastname")]
    public string Family { get; set; }

    [XmlElement("firstname")]
    public string Name { get; set; }

    [XmlElement("middlename")]
    public string Otchestvo { get; set; }

    [XmlElement("company")]
    public string Company { get; set; }

  }

}