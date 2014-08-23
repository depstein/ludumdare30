using UnityEngine;
using System.Collections;

namespace Scripts {
	public class LoadPeople : MonoBehaviour {

		// Use this for initialization
		void Start () {
			Debug.Log(XmlLoading.ReadPersonFromFile("bob.xml").DialogTrees[0].RootNode.Prompt);
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}