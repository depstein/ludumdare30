using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class DialogEngine
    {

        public DialogEngine(DialogTree tree, Context context)
        {
            this.dialogTree = tree;
            this.context = context;
            this.CurrentNode = tree.RootNode;
        }

        public void TakeOption(string option)
        {
            this.context.PromptUsed(dialogTree, CurrentNode, option);
            this.CurrentNode = this.CurrentNode.Answers[option];
        }

        private Context context;
        private DialogTree dialogTree;
        public DialogNode CurrentNode { get; private set; }
    }
}
