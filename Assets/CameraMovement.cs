using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    Transform player;
    float distance;
    public float maxDist = 0.6f;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Leo").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        player = GameObject.Find("Leo").GetComponent<Transform>();
        distance = Vector2.Distance(transform.position, player.position);
        print(distance);

        while(distance > maxDist)
        {
            Vector3 delta = (player.position - transform.position).normalized;
            delta = new Vector3(delta.x/1000, delta.y/1000, 0);

            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + delta;
            distance = Vector2.Distance(transform.position, player.position);
        }
    }
}
