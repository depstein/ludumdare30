using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Scripts {
	public class Person {
		[XmlAttribute]
		public string Name;

		public List<DialogTree> DialogTrees;

		public override string ToString() {
			string str =  "Name: " + Name + "\n";

			foreach(DialogTree tree in DialogTrees) {
				str += "DialogTree:\n" + tree.ToString();
			}

			return str;
		}
	}
}