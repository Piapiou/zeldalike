using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	public EnemyMovement em;
	public Animator anim;
	public AnimationClip animDeath;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void kill(){
		em.StayStill ();
		Destroy (this.gameObject.GetComponent<CircleCollider2D> ());
		anim.SetBool("dying", true);
		Destroy (this.gameObject, animDeath.length);
	}

}
