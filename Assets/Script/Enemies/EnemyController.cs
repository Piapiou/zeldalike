using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public EnemyDeath enemy;

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

	void SufferDamage(int hit){
		this.lifePoints = this.lifePoints - hit;
	}

	void SufferDeath(){
		enemy.kill ();
	}

}
