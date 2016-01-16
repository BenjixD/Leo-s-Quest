using UnityEngine;
using System.Collections;

public class SwitchWeapon : MonoBehaviour {

    private GameObject Weapon1;
    private GameObject Weapon2;
    private GameObject SwordBody;
    private GameObject BowBody;
	Animator anim;

    void Start()
    {	
		Weapon1 = GameObject.Find("Sword");
		if (Weapon1 == null) {
			Debug.Log ("sword not found");
		} else {
			Debug.Log ("sword found!");
		}	
        Weapon2 = GameObject.Find("Bow");
        SwordBody = GameObject.Find("Body");
        BowBody = GameObject.Find("Body2");
		anim = GetComponent<Animator>();
        Weapon2.SetActive(false);
        BowBody.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown(KeyCode.Q) && !anim.GetBool("attack"))
        {
            switchWeapons();
        }
    }

    void switchWeapons()
    {
        if (Weapon1.activeSelf == true)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            BowBody.SetActive(true);
            SwordBody.SetActive(false);
        }
        else
        {
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            BowBody.SetActive(false);
            SwordBody.SetActive(true);
        }
    }
}
