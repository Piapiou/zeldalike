using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	public float speed = 0.0f;
	public Rigidbody2D rb;
	private int dir = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveInDirection (dir);
	}

	void MoveInDirection(int _dir) {
		switch (_dir) {
		case 0 : rb.velocity += new Vector2 (0, speed); break;
		case 1 : rb.velocity += new Vector2 (speed, 0); break;
		case 2 : rb.velocity += new Vector2 (0, -speed); break;
		case 3 : rb.velocity += new Vector2 (-speed, 0); break;
		}
	}

	public void setDir(int _dir){
		dir = _dir;
	}
}
