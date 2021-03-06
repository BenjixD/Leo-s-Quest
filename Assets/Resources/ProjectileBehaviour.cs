﻿using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {

    Rigidbody2D selfRB;
    Collider2D hitbox;

	// Use this for initialization
	void Start () {
        selfRB = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<Collider2D>();
        Destroy(gameObject, 30);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D()
    {
        selfRB.velocity = Vector2.zero;
        Destroy(hitbox, 0.2f);
        Destroy(gameObject, 5);
    }
}
