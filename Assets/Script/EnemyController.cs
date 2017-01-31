using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public EnemyDeath enemy;

	public int lifePoints = 3;
    public bool isVulnerable = true;

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
        if (!isVulnerable)
		    this.lifePoints = this.lifePoints - hit;
	}

	void SufferDeath(){
		enemy.kill ();
	}

}
