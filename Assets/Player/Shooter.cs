using UnityEngine;
using System.Collections;

public class Shooter: MonoBehaviour {

    GameObject prefab;
    Animator parentAnim;
    public float projSpeed = 10f;
    public float spawnModif = 4f;  
	public bool shot = false;
	//static int bow_state = Animator.StringToHash("Bow.Bow_Attack");
	// Use this for initialization
	void Start () {
        prefab = Resources.Load<GameObject>("Prefabs/Arrow");

        parentAnim = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (parentAnim.GetCurrentAnimatorStateInfo(2).IsName("Bow_Attack"))
		{
			if (!shot) {
				shot = true;
				Debug.Log ("pew");
				Vector3 dirMod = new Vector3();
				float angleRad = Mathf.Deg2Rad * parentAnim.GetFloat("relativeAngle");
				dirMod.y -= Mathf.Sin(angleRad)/spawnModif;
				dirMod.x -= Mathf.Cos(angleRad)/spawnModif;

                GameObject projectile = Instantiate(prefab, transform.position + dirMod, Quaternion.identity) as GameObject;
                projectile.layer = gameObject.layer;
				projectile.transform.Rotate(0,0,parentAnim.GetFloat("relativeAngle") - 90);
				Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
				//rb.position = transform.position + new Vector3(0, 3);
				//rb.velocity = new Vector3(0, 5);
				rb.velocity = projSpeed * dirMod;
			}
		}

		else if (Input.GetKeyDown (KeyCode.E) || Input.GetMouseButtonDown (0)) {
			parentAnim.SetBool ("attack", true);
			shot = false;
		}
	}
}
