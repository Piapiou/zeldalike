using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 0.0f;
	private int dir = 0; // N = 0 ; O = 1 ; S = 2 ; E = 3 //

	private bool moving = false;

	public Rigidbody2D rb;

	public Animator anim;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("MovingLoop", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	void ChooseRandomDirection() {
		int rand = (int)(Random.value * 4);
		this.dir = rand;
		anim.SetInteger("dir", dir);
	}

	void MoveInDirection(int _dir) {
		switch (_dir) {
			case 0 : rb.velocity += new Vector2 (0, speed); break;
			case 1 : rb.velocity += new Vector2 (speed, 0); break;
			case 2 : rb.velocity += new Vector2 (0, -speed); break;
			case 3 : rb.velocity += new Vector2 (-speed, 0); break;
		}
	}

	void StayStill(){
		rb.velocity = new Vector2 (0, 0);
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
		anim.SetBool("moving", moving);
		MovingBehaviour ();
	}

	public bool isMoving(){
		return moving;
	}

	public int getDir(){
		return dir;
	}

}
