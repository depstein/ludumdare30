using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public float InitialXVelocity;
    public float Size = 0.25f;
    public GameObject PlanetPrefab;
    private Vector2 lastVelocity;
    public GameObject explosion;
    public AudioSource beep;

    private bool hasBeenDestroyed = false;

    void Awake()
    {
        GetComponent<Rigidbody2D>().mass = Size * 4;
        transform.localScale = new Vector3(Size, Size, 1);
        
        float h, s, v;
        Colors.ColorToHSV(Colors.GetRandomColor(), out h, out s, out v);
        transform.Find("Sprite").GetComponent<SpriteRenderer>().color = Colors.ColorFromHSV(h, s, .95f);
        
    }

    public void DestroyPlanet(int level)
    {
        if (hasBeenDestroyed)
            return;
            
        this.gameObject.collider2D.enabled = false;
        Destroy(rigidbody2D);
        Main.MakeProjectilesAt (this.gameObject, level + 1);
        GetComponent<Animator>().Play("Explode");
        Destroy(this.gameObject, 1f);

        beep.pitch = 1 + Mathf.Pow(1.5f, level) / 15f;

        hasBeenDestroyed = true;

        Main.ShakeCamera(Mathf.Max(StaticScoreboard.planetsDestroyed * .075f, .4f));
    }

    void OnMouseDown()
    {
		if (Main.numClicks > 0)
		{
			Main.hasDestroyedPlanet = true;
        	DestroyPlanet(0);
			Main.numClicks--;
		}
    }

    void FixedUpdate()
    {
        if (rigidbody2D == null)
            return;

        Vector3 pos = transform.position;
        float angle = Mathf.Atan2(pos.y, pos.x);
        //angle = Mathf.PI * 2f - angle;
        angle += Mathf.PI / 2.0f;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle);

        lastVelocity = GetComponent<Rigidbody2D>().velocity;
		Vector3 radius = (Main.staticGravityObject.transform.position - transform.position);
		if (radius.magnitude < 1)
		{
			radius = radius.normalized;
		}
		Vector3 numerator = radius.normalized * Main.staticGravityObject.rigidbody2D.mass;
		float denominator = radius.sqrMagnitude;
		Vector3 force = numerator * Main.GravitationalConstant / denominator;
		rigidbody2D.AddForce(force);
    }
}
