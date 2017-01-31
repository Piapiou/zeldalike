using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public EnemyDeath enemy;
	public GameObject enemySprite;

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
		this.lifePoints = this.lifePoints - hit;
		isHurt = true;
		StartCoroutine(Blink ());
	}

	void SufferDeath(){
		enemy.kill ();
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
