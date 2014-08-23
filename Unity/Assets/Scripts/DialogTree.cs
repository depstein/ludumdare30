using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class DialogTree
    {
        public bool IsAvailable(Context context) { return true; }
        public DialogNode RootNode { get;set; }
		public string Hint { get; set; }
    }
}
