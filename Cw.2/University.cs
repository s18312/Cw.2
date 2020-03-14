using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw._2
{
    [Serializable]
    public class University
    {
        [XmlAttribute(AttributeName = "createdAt")]
        public string createdAt = DateTime.Today.ToShortDateString();
        [XmlAttribute(AttributeName = "author")]
        public string name = "Jakub Bogusławski";

        public HashSet<Student> studenci;
        public List<ActiveStudy> wydzialy;
    }
}
