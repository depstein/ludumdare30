using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scripts
{
    public class DialogNode
    {
        [XmlAttribute]
        public DialogType Type { get; set; }

        [XmlAttribute]
        public string Prompt { get; set; }

        [XmlAttribute]
        public string Id { get; set; }

        public List<DialogOption> Answers { get; set; }

        public override string ToString()
        {
            string str = "Type: " + Type + ", Id: " + Id + ", Prompt: " + Prompt + ", Answers:\n";
            foreach (DialogOption opt in Answers)
            {
                str += opt.Response + ": " + opt.Statement.ToString();
            }
            return str;
        }
    }
}
