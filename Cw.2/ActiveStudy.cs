using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw._2
{
    [Serializable]
    public class ActiveStudy
    {
        [XmlElement(ElementName = "studiesName")]
        public string Wydzial { get; set; }
        [XmlElement(ElementName = "numberOfStudents")]
        public int IleStud { get; set; }


        
    }
}