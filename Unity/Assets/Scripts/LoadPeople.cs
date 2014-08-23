using UnityEngine;
using System.Collections;

namespace Scripts {
	public class LoadPeople : MonoBehaviour {

		// Use this for initialization
		void Start () {
			Debug.Log(XmlLoading.ReadFolderOfPeople()[0]);
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}