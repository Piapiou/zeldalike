using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {
    
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Ennemy")
            Destroy(coll.gameObject);
        else
            Debug.Log(coll.collider.tag);
    }

}
