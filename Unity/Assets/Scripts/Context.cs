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

        public void PromptUsed(PersonSelectionOption dialogTree, DialogNode CurrentNode, DialogOption SelectedOption)
        {
        	idsVisited.Add(SelectedOption.Value.Id);
            Debug.Log(String.Join(", ", idsVisited.ToArray()));
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
    }
}
