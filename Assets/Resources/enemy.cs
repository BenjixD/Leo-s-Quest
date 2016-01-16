using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	Collider2D hitbix;

	// Use this for initialization
	void Start () {
		hitbix = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.layer != 23) {
			string killer = col.gameObject.name;
			int layer = col.gameObject.layer;
			Debug.Log ("Fuck " + killer + " (" + layer + ") killed me");
			Destroy (hitbix);
			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			rb.AddTorque (90001);
			rb.gravityScale = 0.1f;
			Destroy (gameObject, 3);
		}
	}
		
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Sword") {
			Debug.Log ("Leo's Sword: I hath slain a sword");
			Rigidbody2D r = GetComponent<Rigidbody2D> ();
			r.AddTorque (-3218321f);
		}
	}
}
