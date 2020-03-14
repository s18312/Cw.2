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
        [XmlAttribute(attributeName: "studies")]
        public String Wydzial { get; set; }
        [XmlAttribute(attributeName: "mode")]
        public String Tryb { get; set; }
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

        public String toString()
        {
            return Imie + " " + Nazwisko + " " + Wydzial + " " + Tryb + " " + Indeks + " " + DataRoz + " " + Mail + " " + ImieMatki + " " + ImieOjca;
        }
    }
}
