using UnityEngine;
using System.Collections;

public class VaatiBallController : MonoBehaviour
{

    public GameObject Vaati;
    public GameObject player;
    public bool moveToPlayer;
    public Rigidbody2D rb;
    public float speed = 1;
    public int damage;
    public float knockback;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, 0);
        Vector3 target;
        if (moveToPlayer)
        {
            target = player.transform.position;
        }
        else
        {
            target = Vaati.transform.position;
        }

        vel = (target - this.transform.position).normalized * speed;
        rb.velocity = vel;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "SwordPlayer")
        {
            moveToPlayer = false;
            gameObject.layer = 21;
        }
        Debug.Log("Trigger :" + coll.tag);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collider :" + coll.collider.tag);
        if (coll.collider.tag == "Player")
        {
            player.GetComponent<playerController>().getDamage(damage);
            player.GetComponent<playerController>().addKnockBack(-coll.contacts[0].normal*knockback);
            Destroy(gameObject);
        }

        if (coll.collider.tag == "Boss" && !moveToPlayer)
        {
            Vaati.GetComponent<VaatiController>().SendBackBall();
        }
    }
}