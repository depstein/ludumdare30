using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Scripts
{
    public class DialogOption
    {
        [XmlAttribute]
        public string Key;
        public DialogNode Value;
    }
}
