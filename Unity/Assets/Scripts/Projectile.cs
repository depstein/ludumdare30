using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public int level;
	void Awake() {
		InvokeRepeating("DieInAFire", 5, 5f);
	}

	void DieInAFire() {
		GameObject.Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        var other = collision.gameObject.GetComponent<Planet>();
        if (other != null)
        {
			/*Vector2 myPosition = GetComponent<Rigidbody2D>().position;
			Vector2 myVelocity = GetComponent<Rigidbody2D>().velocity;
			int numDirections = 3;
			int angleDif = 360 / numDirections;
			float dirMag = 3.0f / ((float)numDirections);
			float angleRad = Mathf.Deg2Rad * angleDif;
			for (int x = 0; x < numDirections; x++)
			{
				GameObject projectile = GameObject.Instantiate(ProjectilePrefab) as GameObject;
				Vector2 vectorDir = new Vector2(Mathf.Cos(angleRad * x), Mathf.Sin(angleRad * x)) * dirMag;
				var projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
				projectileRigidBody.velocity = vectorDir;
				
				Vector2 projectilePosition = myPosition + projectileRigidBody.velocity.normalized * projectile.collider2D.bounds.size.magnitude;
				projectileRigidBody.position = projectilePosition;
			}*/

			/*a.rigidbody2D.position = otherPosition + (newSize * 2 * new Vector2(-normal.normalized.y, normal.normalized.x));
			b.rigidbody2D.position = otherPosition + (newSize * 2 * new Vector2(normal.normalized.y, -normal.normalized.x));

			a.rigidbody2D.velocity = 0.8f * otherVelocity + 0.2f * otherVelocity.magnitude * (new Vector2(-normal.normalized.y, normal.normalized.x));
			b.rigidbody2D.velocity = 0.8f * otherVelocity + 0.2f * otherVelocity.magnitude * (new Vector2(normal.normalized.y, -normal.normalized.x));
*/

			other.GetComponent<Planet>().DestroyPlanet(level);
			StaticScoreboard.AddPoints((int)(Mathf.Pow(2, level)*1000));
			GameObject.Destroy (this.gameObject);
        }
	}
}
