using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    Transform player;
    Rigidbody2D cam;
    float distance;
    public float maxDist = 0.6f;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Leo").GetComponent<Transform>();
        cam = GetComponent<Rigidbody2D>();
        this.transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        try
        {
            player = GameObject.Find("Leo").GetComponent<Transform>();
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("GG");
            Time.timeScale = 0.0f;
            throw;
        }
        
        distance = Vector2.Distance(transform.position, player.position);

        if (distance > maxDist)
        {
            Vector3 delta = (player.position - transform.position).normalized;
            delta = new Vector3(delta.x * 2, delta.y * 2, 0);

            cam.velocity = delta;

            //[OLD] USE OF TRANSFORM POSTION
            //this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + delta;
            //distance = Vector2.Distance(transform.position, player.position);
        }
    }
}
