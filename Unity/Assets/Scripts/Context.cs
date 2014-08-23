using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class Context
    {
    	private HashSet<string> idsVisited = new HashSet<string>();
        private HashSet<DialogTree> treesExplored = new HashSet<DialogTree>();

        public void PromptUsed(PersonSelectionOption dialogTree, DialogNode CurrentNode, DialogOption SelectedOption)
        {
        	idsVisited.Add(SelectedOption.Statement.Id);
            treesExplored.Add(dialogTree.DialogTree);
        }

        public bool MeetsPredicates(string[] predicates) {
        	if(predicates == null) {
        		return true;
        	}
        	foreach(string s in predicates) {
        		if(!idsVisited.Contains(s)) {
        			return false;
        		}
        	}
        	return true;
        }

        public bool TreeUnexplored(DialogTree tree) {
            return !treesExplored.Contains(tree);
        }
    }
}
