using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw._2
{
    
    [Serializable]
    public class Studies
    {

        [XmlElement(ElementName = "name")]
        public string Wydzial { get; set; }
        [XmlElement(ElementName = "mode")]
        public string Tryb { get; set; }

        public override string ToString()
        {
            return Tryb + " " + Wydzial;
        }
    }
}
