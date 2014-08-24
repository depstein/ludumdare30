using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public int level;
	void Awake() {
		Invoke ("DieInAFire", 2.5f);
	}

	void DieInAFire() {
		GameObject.Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        var other = collision.gameObject.GetComponent<Planet>();
        if (other != null)
        {
			other.GetComponent<Planet>().DestroyPlanet(level);
			StaticScoreboard.AddPoints((int)(Mathf.Pow(2, level)*1000));
			GameObject.Destroy (this.gameObject);
        }
	}
}
