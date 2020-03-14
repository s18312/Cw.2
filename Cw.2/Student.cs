using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw._2
{
    public class Student
    {
        [XmlAttribute(attributeName: "fname")]
        public String Imie { get; set; }
        [XmlAttribute(attributeName: "lname")]
        public String Nazwisko { get; set; }
       
        [XmlAttribute(attributeName: "indexNumber")]
        public String Indeks { get; set; }
        [XmlAttribute(attributeName: "startDate")]
        public String DataRoz { get; set; }
        [XmlAttribute(attributeName: "email")]
        public String Mail { get; set; }
        [XmlAttribute(attributeName: "mothersName")]
        public String ImieMatki { get; set; }
        [XmlAttribute(attributeName: "fathersName")]
        public String ImieOjca { get; set; }

        public Studies Studia { get; set; }

        public override String ToString()
        {
            return Imie + " " + Nazwisko + " " + Indeks + " " + DataRoz + " " + Mail + " " + ImieMatki + " " + ImieOjca + Studia;
        }
    }
}
