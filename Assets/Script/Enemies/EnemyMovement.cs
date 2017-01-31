using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private Vector2 vel;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		rb.velocity = vel;
	}

	public void setVelocity(Vector2 _vel){
		this.vel = _vel;
	}
}