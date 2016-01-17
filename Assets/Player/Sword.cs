using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    Animator anim;
    Collider2D hitbix;

    // Use this for initialization
    void Start () {
        anim = GetComponentInParent<Animator>();
        hitbix = GetComponent<Collider2D>();
        hitbix.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("attack", true);
            
        }
        hitbix.enabled = anim.GetBool("attack");
    }

	void onTriggerEnter2D(Collision2D col) {
		if (col.gameObject.layer == 19) {
			Debug.Log ("Die, " + col.gameObject.name);
            Rigidbody2D otherRB = col.gameObject.GetComponent<Rigidbody2D>();
            otherRB.AddTorque(300000);
			Destroy (col.gameObject, 3);
		}
	}
}
