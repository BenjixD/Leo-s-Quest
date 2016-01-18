using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {

    public int HP = 5;

    Collider2D hitbox;
    GameObject parent;
    int selfLayer;
    float invincibilityTimer;
    

    // Use this for initialization
    void Start() {
        parent = gameObject.transform.parent.gameObject;
        hitbox = GetComponent<Collider2D>();
        selfLayer = parent.layer;
        gameObject.layer = selfLayer;
        invincibilityTimer = 2.0f;
        Debug.Log(parent.name + ": I have " + HP + "HP.");
    }

    

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
	    if (isEnemy(col.gameObject.layer))
        {
            HP--;
            Debug.Log(parent.name + ": Ow! " + col.gameObject.name + " hit me! I have " + HP + "HP left!");
            StartCoroutine(invincible());
            if (HP <= 0)
            {
                Debug.Log(parent.name + ": I am dead!");
                Destroy(hitbox);
                Destroy(parent, 2);
            }
        }
	}

    IEnumerator invincible()
    {
        Debug.Log(parent.name + ": Invincible for " + invincibilityTimer + " seconds");
        hitbox.enabled = false;
        yield return new WaitForSeconds(invincibilityTimer);
        hitbox.enabled = true;
        Debug.Log(parent.name + ": Invincibility over");
    }

    bool isEnemy(int otherLayer)
    {
        if (selfLayer == 19)
            return (otherLayer == 22);
        return (otherLayer == 19);
    }
}
