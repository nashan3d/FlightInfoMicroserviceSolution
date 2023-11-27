

using System.Xml.Serialization;

namespace FlightInfo.Domain
{
    [XmlRoot("Flights")] 

    public class Flights
    {      

        [XmlElement("Flight")]
        public Flight[] FlightList { get; set; }

    }

    public class Flight
    {

        [XmlElement(ElementName = "FlightNumber")]
        public string FlightNumber { get; set; }
        [XmlElement(ElementName = "DepartureCity")]
        public string DepartureCity { get; set; }
        [XmlElement(ElementName = "DestinationCity")]
        public string DestinationCity { get; set; }
        [XmlElement(ElementName = "DepartureTime")]
        public DateTime DepartureTime { get; set; }
        [XmlElement(ElementName = "ArrivalTime")]
        public DateTime ArrivalTime { get; set; }

    }


}
