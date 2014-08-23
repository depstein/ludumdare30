using UnityEngine;
using System.Collections;

namespace Scripts {
	public class LoadPeople : MonoBehaviour {

		// Use this for initialization
		void Start () {
			Debug.Log(XmlLoading.ReadPersonFromFile("bob.xml").Name);
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}