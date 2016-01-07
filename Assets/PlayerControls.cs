using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    protected Rigidbody2D r;
    bool facingRight = true;
    public float moveSpeed = 4.0f;
    Animator anim;
    Camera cam;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        r = GetComponent<Rigidbody2D>();
        r.gravityScale = 0;
        cam = GetComponentInChildren<Camera>();
        // cam = GameObject.Find("BackgroundNavyGridSprite").GetComponentInChildren<Camera>();
        // above line is for camera that is not a child of this object
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");


        Vector2 velo = new Vector2(hor * moveSpeed, ver * moveSpeed);

        Vector3 mousePos = Input.mousePosition;
        Vector3 charPos = cam.WorldToScreenPoint(r.position);
        anim.SetFloat("mouseX", mousePos.x);
        anim.SetFloat("mouseY", mousePos.y);
        anim.SetFloat("CharX", charPos.x);
        anim.SetFloat("CharY", charPos.y);

        float mouseRelativeDeg = 180 + Mathf.Rad2Deg * Mathf.Atan2(mousePos.y - charPos.y, mousePos.x -charPos.x);
        anim.SetFloat("relativeAngle", mouseRelativeDeg);

        r.velocity = velo;

        if (hor < 0 && facingRight) Flip();
        else if (hor > 0 && !facingRight) Flip();
	
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    float Sign(float i)
    {
        if (i < 0) return -1;
        else if (i > 0) return 1;
        return 0;
    }


}
