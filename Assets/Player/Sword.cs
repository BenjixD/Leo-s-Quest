using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("slash", true);
        }
    }
}
