using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	private bool playerInRange = false;
	private bool attacked = false;
	private bool moving;
	private int dir;
	public EnemyMovement movement;
	public GameObject projectilePrefab;
	public Transform position;
	private GameObject projectile;

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
		//if (true) {
			movement.StayStill();
			print ("attaque");
			attack ();
		}
	}

	void attack(){
		if (!attacked) {
			projectile = GameObject.Instantiate (projectilePrefab);
			projectile.GetComponent<ProjectileMovement> ().setDir (dir);
			projectile.transform.position = position.position;
			attacked = true;
		}
	}

}
