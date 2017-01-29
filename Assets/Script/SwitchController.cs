using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

    public bool isOn = false;
    public bool canSwitchBackOff = false;
    public Animator anim;

	// Use this for initialization
	void Start () {

        anim.SetBool("isOn", isOn);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.collider.tag);
        if (coll.collider.tag == "Explosion" || coll.collider.tag == "SwordPlayer" || coll.collider.tag == "FriendProjectile")
        {
            if (isOn == true && canSwitchBackOff == true)
            {
                isOn = false;
                anim.SetBool("isOn", false);
            }
            else if (isOn == false)
            {
                isOn = true;
                anim.SetBool("isOn", true);
            }

        }
            
    }
}
