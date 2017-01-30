using UnityEngine;
using System.Collections;

public class arrowController : MonoBehaviour {

    public int direction = 0;// N = 0 ; O = 1 ; S = 2 ; E = 3 //
    public float speed;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject player;
    public BoxCollider2D verticalCollider;
    public BoxCollider2D horizontalCollider;
    public float knockBack = 1.0f;
    public int damage = 2;

    // Use this for initialization
    void Start () {
        Time.timeScale = 0.1f;
        anim.SetInteger("direction", direction);
        if (direction%2 == 1)
        {
            horizontalCollider.enabled = true;
            verticalCollider.enabled = false;
        } else
        {
            horizontalCollider.enabled = false;
            verticalCollider.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

        var vel = rb.velocity;

        vel.x = 0;
        vel.y = 0;

        switch (direction)
        {
            case 0:
                vel.y = speed;
                break;
            case 1:
                vel.x = speed;
                break;
            case 2:
                vel.y = -speed;
                break;
            case 3:
                vel.x = -speed;
                break;
            default:
                break;
        }

        rb.velocity = vel;

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            coll.gameObject.GetComponent<playerController>().addKnockBack(-coll.contacts[0].normal*knockBack);
            coll.gameObject.GetComponent<playerController>().getDamage(damage);
        }
        
        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
