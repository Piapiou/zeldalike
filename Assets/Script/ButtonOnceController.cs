using UnityEngine;
using System.Collections;

public class ButtonOnceController : MonoBehaviour {

    public bool isPushed;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        isPushed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            isPushed = true;
            anim.SetBool("buttonPressed", true);
        }
    }
}
