using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponentInParent<Animator>();
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
    }

	void onTriggerEnter2D(Collision2D col) {
		if (col.gameObject.layer == 19) {
			Debug.Log ("Die, " + col.gameObject.name);
			Destroy (col.gameObject);
		}
	}
}
