using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	bool playerInRange = false;
	bool moving;
	int dir;
	public EnemyMovement movement;
	public GameObject projectile;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		moving = movement.isMoving ();
		dir = movement.getDir ();
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			if(!playerInRange){
				playerInRange = true;
			}
		}
	}

	void attack(){
		
	}

}
