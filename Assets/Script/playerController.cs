﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public GameController gameController;

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
    

    // Use this for initialization
    void Start () {
        for (int i =0; i < 4; i++)
            swordHitBox[i].enabled = false;
        isAttacking = false;
        isShielding = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameController.inventoryIsActive)
            UpdateMove();
    }

    void UpdateMove()
    {
        var vel = rb.velocity;

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
        rb.velocity = vel;
    }

    public void Attack()
    {
        isAttacking = true;
        anim.SetBool("isAttacking", true);
        swordHitBox[direction].enabled = true;
        StartCoroutine(StopAttack(swordAnimation.length));
    }

    IEnumerator StopAttack(float time)
    {
        yield return new WaitForSeconds(time);
        isAttacking = false;
        swordHitBox[direction].enabled = false;
        anim.SetBool("isAttacking", false);
    }

    public void ShieldUp()
    {

    }

    public void ShieldDown()
    {

    }

}
