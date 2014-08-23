using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public DialogType Type { get; set; }
        public string Prompt { get; set; }
        public List<DialogOption> Answers { get; set; }
    }
}
