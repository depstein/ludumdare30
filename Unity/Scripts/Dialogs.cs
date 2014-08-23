using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class PossibleDialogs
    {
        public PossibleDialogs(List<DialogTree> trees)
        {
            Trees = trees;
        }

        public List<DialogTree> Trees { get; private set; }
    }
}
