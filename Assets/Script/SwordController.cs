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
        Debug.Log(coll.tag);
        if (coll.tag == "Ennemy" || coll.tag == "Boss") {
			EnemyHealth eh = coll.gameObject.GetComponent<EnemyHealth> ();
			eh.SufferKnockback (new Vector2(0,0));
			eh.SufferDamage (player.gameObject.GetComponent<playerController>().swordDamage);
		}
    }

}
