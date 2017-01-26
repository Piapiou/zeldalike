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

    // Use this for initialization
    void Start () {
        anim.SetInteger("direction", direction);
        if (direction > 1)
        {
            verticalCollider.enabled = false;
        } else
        {
            horizontalCollider.enabled = false;
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


        Debug.Log((player.transform.position - this.transform.position).sqrMagnitude);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {

        Destroy(gameObject);
    }
}
