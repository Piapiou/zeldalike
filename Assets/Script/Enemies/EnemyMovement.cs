using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 0.0f;
	private int dir = 0; // N = 0 ; O = 1 ; S = 2 ; E = 3 //

	private bool moving = false;

	public Rigidbody2D rb;

	public Animator anim;

	private Vector2 vel;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("MovingLoop", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = vel;
	}
		
	void ChooseRandomDirection() {
		int rand = (int)(Random.value * 4);
		this.dir = rand;
		anim.SetInteger("dir", dir);
	}

	public void MoveInDirection(int _dir) {
		switch (_dir) {
			case 0 : vel = new Vector2 (0, speed); break;
			case 1 : vel = new Vector2 (speed, 0); break;
			case 2 : vel = new Vector2 (0, -speed); break;
			case 3 : vel = new Vector2 (-speed, 0); break;
		}
	}

	public void StayStill(){
		anim.SetInteger("dir", dir);
		anim.SetBool("moving", false);
		vel = new Vector2 (0, 0);
	}

	void MovingBehaviour(){
		if (this.moving){
			ChooseRandomDirection ();
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
			pc.getDamage (2);
		}
	}

}
