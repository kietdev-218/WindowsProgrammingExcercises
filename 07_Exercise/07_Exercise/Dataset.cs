using System.Collections.Generic;
using System.Xml.Serialization;

namespace _07_Exercise.Model
{
    [XmlRoot("dataset")]
    public class Dataset
    {

        [XmlElement("Student")]
        public List<Student> Students { get; set; }
    }
}
 