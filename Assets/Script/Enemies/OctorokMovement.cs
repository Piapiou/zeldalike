using UnityEngine;
using System.Collections;

public class OctorokMovement : MonoBehaviour {

	public float speed = 0.0f;
	public int dir = 0; // N = 0 ; O = 1 ; S = 2 ; E = 3 //
	public int blockedDir = -1;

	private bool moving = false;

	public Animator anim;

	private Vector2 vel;
	public EnemyMovement move;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("MovingLoop", 0.0f, 0.5f+ChooseRandomTime());
	}

	// Update is called once per frame
	void Update () {
	}

	void ChooseRandomDirection() {
		int rand = (int)(Random.value * 4);
		this.dir = rand;
		anim.SetInteger("dir", dir);
	}

	float ChooseRandomTime() {
		float rand = Random.value;
		return rand;
	}

	public void MoveInDirection(int _dir) {
		switch (_dir) {
		case 0 : move.setVelocity(new Vector2 (0, speed)); break;
		case 1 : move.setVelocity(new Vector2 (speed, 0)); break;
		case 2 : move.setVelocity(new Vector2 (0, -speed)); break;
		case 3 : move.setVelocity(new Vector2 (-speed, 0)); break;
		}
	}

	public void StayStill(){
		anim.SetInteger("dir", dir);
		anim.SetBool("moving", false);
		move.setVelocity(new Vector2 (0, 0));
	}

	void MovingBehaviour(){
		if (this.moving){
			ChooseRandomDirection ();
			while (this.dir == this.blockedDir) {
				ChooseRandomDirection ();
			}
			blockedDir = -1;
			MoveInDirection(this.dir);
		} else {
			StayStill ();
		}
	}

	void MovingLoop(){
		moving = !moving;
		anim.SetBool("shooting", false);
		anim.SetBool("moving", moving);
		MovingBehaviour ();
	}

	public bool isMoving(){
		return moving;
	}

	public int getDir(){
		return dir;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == ("Player")){
			playerController pc = coll.gameObject.GetComponent<playerController> ();
			pc.addKnockBack (coll.contacts[0].normal*-100);
			pc.getDamage (2);
		}
		StayStill ();
		blockedDir = dir;
	}

}
