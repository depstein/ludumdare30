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
	}
}