using UnityEngine;
using System.Collections;

public class TestFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyUp (KeyCode.UpArrow)){
			EnemyDeath killer = GameObject.Find ("Octorok").GetComponent<EnemyDeath>();
			killer.kill ();
		}
	}
}
