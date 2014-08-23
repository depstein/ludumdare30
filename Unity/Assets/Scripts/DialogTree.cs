using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class DialogTree
    {
        public virtual bool IsAvailable(Context context) { return true; }
        public DialogNode RootNode { get;set; }

        public override string ToString() {
        	return "Node:" +  RootNode.ToString();
        }
    }
}
