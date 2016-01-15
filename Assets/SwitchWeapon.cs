using UnityEngine;
using System.Collections;

public class SwitchWeapon : MonoBehaviour {

    private GameObject Weapon1;
    private GameObject Weapon2;
    private GameObject SwordBody;
    private GameObject BowBody;

    void Start()
    {
        Weapon1 = GameObject.Find("Sword");
        Weapon2 = GameObject.Find("Bow");
        SwordBody = GameObject.Find("Body");
        BowBody = GameObject.Find("Body2");
        Weapon2.SetActive(false);
        BowBody.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
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
