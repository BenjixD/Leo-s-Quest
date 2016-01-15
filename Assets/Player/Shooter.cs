using UnityEngine;
using System.Collections;

public class Shooter: MonoBehaviour {

    GameObject prefab;
    Animator parentAnim;
    public float projSpeed = 10f;
    public float spawnModif = 4f;  

	// Use this for initialization
	void Start () {
        prefab = Resources.Load<GameObject>("Prefabs/Arrow");

        parentAnim = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Vector3 dirMod = new Vector3();
            float angleRad = Mathf.Deg2Rad * parentAnim.GetFloat("relativeAngle");
            dirMod.y -= Mathf.Sin(angleRad)/spawnModif;
            dirMod.x -= Mathf.Cos(angleRad)/spawnModif;
        
            GameObject projectile = Instantiate(prefab, transform.position + dirMod, Quaternion.identity) as GameObject;
            projectile.transform.Rotate(0,0,parentAnim.GetFloat("relativeAngle") - 90);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            //rb.position = transform.position + new Vector3(0, 3);
            //rb.velocity = new Vector3(0, 5);
            rb.velocity = projSpeed * dirMod;
            
        }
	
	}
}
