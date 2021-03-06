﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public EnemyMovement em;
	public Animator anim;
	public AnimationClip animDeath;

	public GameObject enemySprite;

    public bool isVulnerable;

	private bool isHurt = false;
	public int lifePoints = 3;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(this.lifePoints <= 0){
			SufferDeath ();
		}
	}

	public void SufferKnockback(Vector2 knock){

	}

	public void SufferDamage(int hit){
        if (isVulnerable)
        {
            this.lifePoints = this.lifePoints - hit;
            isHurt = true;
            StartCoroutine(Blink());
        }
	}

	public void SufferDeath(){
		em.setVelocity (new Vector2(0,0));
		Destroy (this.gameObject.GetComponent<CircleCollider2D> ());
		anim.SetBool("dying", true);
		Destroy (this.gameObject, animDeath.length);
	}

	IEnumerator Blink(){
		SpriteRenderer es = enemySprite.GetComponent<SpriteRenderer> ();
		for (int n = 0; n < 3; n++) {
			es.color = Color.red;
			yield return new WaitForSeconds (0.1f);
			es.color = Color.white;
			yield return new WaitForSeconds (0.1f);
		}
	}
}
