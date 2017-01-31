using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	private bool attacked = false;
	private bool moving;
	private int dir;

	public EnemyMovement movement;
	public GameObject projectilePrefab;
	public Transform position;
	private GameObject projectile;

	public GameObject downZone;
	public GameObject upZone;
	public GameObject leftZone;
	public GameObject rightZone;

	public Animator anim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		dir = movement.getDir ();
		moving = movement.isMoving ();
		setColliders ();
	}

	void OnTriggerStay2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
		//if (true) {
			movement.StayStill();
			attack ();
		}
	}

	void attack(){
		if (projectile == null) {
			anim.SetBool("shooting", true);
			projectile = GameObject.Instantiate (projectilePrefab);
			projectile.GetComponent<ProjectileMovement> ().setDir (dir);
			projectile.transform.position = setProjectilePosition ();
		}
	}

	Vector3 setProjectilePosition(){
		Vector3 projectilePosition = position.position;
		switch (dir) {
		case 0 : projectilePosition += new Vector3 (0, 0.6f, 0); break;
		case 1 : projectilePosition += new Vector3 (0.8f, -0.4f, 0); break;
		case 2 : projectilePosition += new Vector3 (0, -0.9f, 0); break;
		case 3 : projectilePosition += new Vector3 (-0.8f, -0.4f, 0); break;
		}
		return projectilePosition;
	}

	void setColliders(){
		BoxCollider2D downCollider = downZone.GetComponent<BoxCollider2D> ();
		BoxCollider2D upCollider = upZone.GetComponent<BoxCollider2D> ();
		BoxCollider2D rightCollider = rightZone.GetComponent<BoxCollider2D> ();
		BoxCollider2D leftCollider = leftZone.GetComponent<BoxCollider2D> ();
		switch(dir){
		case 0:
			downCollider.enabled = false;
			upCollider.enabled = true;
			rightCollider.enabled = false;
			leftCollider.enabled = false;
			break;
		case 1:
			downCollider.enabled = false;
			upCollider.enabled = false;
			rightCollider.enabled = true;
			leftCollider.enabled = false;
			break;
		case 2:
			downCollider.enabled = true;
			upCollider.enabled = false;
			rightCollider.enabled = false;
			leftCollider.enabled = false;
			break;
		case 3:
			downCollider.enabled = false;
			upCollider.enabled = false;
			rightCollider.enabled = false;
			leftCollider.enabled = true;
			break;
		}
	}

}
