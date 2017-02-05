using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public GameController gameController;
    public SpriteRenderer sprite;

    public int maxHealth = 16;
    public int health = 16;
    public int swordDamage;

    public int direction; // N = 0 ; O = 1 ; S = 2 ; E = 3 //

    public float speed = 1.0f;
    public float speedWithShield = 0.5f;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;
    public AnimationClip swordAnimation;

    public PolygonCollider2D[] swordHitBox;
    private bool isAttacking;
    private bool isShielding;

    private Vector2 knockBack;
    

    // Use this for initialization
    void Start () {
        for (int i =0; i < 4; i++)
            swordHitBox[i].enabled = false;
        isAttacking = false;
        isShielding = false;
        knockBack = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameController.inventoryIsActive && !isDead())
            UpdateMove();
    }

    void UpdateMove()
    {
        if (Time.timeScale != 0.0)
        {
            Vector2 vel = rb.velocity;

            vel.x = 0;
            vel.y = 0;

            float s;
            if (isShielding)
                s = speedWithShield;
            else
                s = speed;

            if (!isAttacking)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                    vel.y -= s;
                if (Input.GetKey(KeyCode.UpArrow))
                    vel.y += s;
                if (Input.GetKey(KeyCode.LeftArrow))
                    vel.x -= s;
                if (Input.GetKey(KeyCode.RightArrow))
                    vel.x += s;
            }

            anim.SetBool("isMoving", false);
            if (vel.sqrMagnitude > 0)
                anim.SetBool("isMoving", true);

            if (!isShielding)
            {
                if (vel.x > 0)
                {
                    direction = 1;
                }
                else if (vel.x < 0)
                {
                    direction = 3;
                }
                else if (vel.y > 0)
                {
                    direction = 0;
                }
                else if (vel.y < 0)
                {
                    direction = 2;
                }
                anim.SetInteger("Direction", direction);
            }
            vel += knockBack;
            rb.velocity = vel;
            knockBack = new Vector2(0, 0);
        }
    }

    public void Attack()
    {

        isAttacking = true;
        anim.SetBool("isAttacking", true);
        swordHitBox[direction].enabled = true;
        swordHitBox[direction].isTrigger = true;
        StartCoroutine(StopAttack(swordAnimation.length));
    }

    IEnumerator StopAttack(float time)
    {
        yield return new WaitForSeconds(time);
        swordHitBox[direction].isTrigger = false;
        isAttacking = false;
        swordHitBox[direction].enabled = false;

        anim.SetBool("isAttacking", false);
    }

    public void ShieldUp()
    {
        isShielding = true;
        anim.SetBool("isShielding", true);
    }

    public void ShieldDown()
    {
        isShielding = false;
        anim.SetBool("isShielding", false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.collider.name)
        {
            case "UpLimit":
                gameController.GetComponent<GameController>().moveRoom(0);
                break;
            case "RightLimit":
                gameController.GetComponent<GameController>().moveRoom(1);
                break;
            case "DownLimit":
                gameController.GetComponent<GameController>().moveRoom(2);
                break;
            case "LeftLimit":
                gameController.GetComponent<GameController>().moveRoom(3);
                break;
            default:
                break;
        }
    }

    public void addKnockBack(Vector2 knock)
    {
        knockBack += knock;
    }

    public void getDamage(int damage)
    {
        health -= damage;
		if (health > maxHealth){
			health = maxHealth;
		}
        if (damage > 0)
            StartCoroutine(Blink());
    }
    
    IEnumerator Blink()
    {
        for (int n = 0; n < 3; n++)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public bool isDead()
    {
        return (health <= 0);
    }
}
