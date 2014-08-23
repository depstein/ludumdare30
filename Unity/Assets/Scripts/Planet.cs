using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    public float InitialXVelocity;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(InitialXVelocity, 0.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
