using UnityEngine;
using System.Collections;

public class SortedParticle : MonoBehaviour {
	public string sortingLayer;
	public int sortingOrder;

	void Awake () {
		particleSystem.renderer.sortingLayerName = sortingLayer;
        particleSystem.renderer.sortingOrder = sortingOrder;
	}
}