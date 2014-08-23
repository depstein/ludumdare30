using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scripts
{
    public class DialogTree
    {
        public virtual bool IsAvailable(Context context) { return true; }
        public DialogNode RootNode { get;set; }
        [XmlAttribute]
		public string Hint { get; set; }

        public override string ToString() {
        	return "Node:" +  RootNode.ToString();
        }
    }
}
