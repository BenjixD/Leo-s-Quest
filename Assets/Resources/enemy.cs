using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {
        Debug.Log("Something bumped into me and possibly took damage");
    }
		
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "Projectile")
        {
            Debug.Log("Enemy: I'm hit!");
            rb.AddTorque(30000000);
            Destroy(gameObject, 3);
            rb.gravityScale = 0.03f;
            GetComponent<Collider2D>().enabled = false;
        }
	}

}
