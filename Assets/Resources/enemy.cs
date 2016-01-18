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
        Debug.Log("Enemy: Something bumped into me and possibly took damage");
    }
		
	void OnTriggerEnter2D (Collider2D other) {
		
	}

}
