using UnityEngine;
using System.Collections;

public class AutomaticHealing : MonoBehaviour {

	public int amount = 4;
	private playerController pc;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == ("Player")){
			playerController pc = coll.GetComponent<playerController> ();
			pc.getDamage (-amount);
		}
		Destroy (this.gameObject);
	}

}
