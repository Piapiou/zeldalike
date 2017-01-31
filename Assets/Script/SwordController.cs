using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {
    
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.tag == "Ennemy") {
			EnemyController ec = coll.gameObject.GetComponent<EnemyController> ();
			ec.SufferKnockback (new Vector2(0,0));
			ec.SufferDamage (player.gameObject.GetComponent<playerController>().swordDamage);
		}
        else
            Debug.Log(coll.tag);
    }

}
