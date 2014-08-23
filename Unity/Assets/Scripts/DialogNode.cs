using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public enum DialogType
    {
        Prompt,
        Terminal
    }

    public class DialogNode
    {
        public DialogType Type { get; set; }
        public string Prompt { get; set; }
        public Dictionary<string, DialogNode> Answers { get; set; }
    }
}
