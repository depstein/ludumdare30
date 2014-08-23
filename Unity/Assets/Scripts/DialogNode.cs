using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scripts
{
    public class DialogOption {
        public string Key;
        public DialogNode Value;
    }

    public enum DialogType
    {
        Prompt,
        Terminal
    }

    public class DialogNode
    {
        [XmlAttribute]
        public DialogType Type { get; set; }
        [XmlAttribute]
        public string Prompt { get; set; }
        public List<DialogOption> Answers { get; set; }
    }
}
