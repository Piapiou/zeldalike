using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
    
    public float speed = 1.0f;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;

    private Vector2 direction;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        var vel = rb.velocity;

        vel.x = 0;
        vel.y = 0;

        if (Input.GetKey(KeyCode.DownArrow))
            vel.y -= speed;
        if (Input.GetKey(KeyCode.UpArrow))
            vel.y += speed;
        if (Input.GetKey(KeyCode.LeftArrow))
            vel.x -= speed;
        if (Input.GetKey(KeyCode.RightArrow))
            vel.x += speed;

        if (vel.x > 0)
            anim.SetInteger("Direction", 3);
        else if (vel.x < 0)
            anim.SetInteger("Direction", 2);
        else if (vel.y > 0)
            anim.SetInteger("Direction", 0);
        else if (vel.y < 0)
            anim.SetInteger("Direction", 1);

        rb.velocity = vel;

    }
}
