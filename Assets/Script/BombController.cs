using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour
{

    public Animator anim;
    public CircleCollider2D hitbox;
    public AnimationClip animExplosion;

    // Use this for initialization
    void Start()
    {
        hitbox.enabled = false;
        StartCoroutine(TriggerSecondAnimationPhase(2.0f));
        StartCoroutine(TriggerExplosion(4.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TriggerSecondAnimationPhase(float time)
    {
        yield return new WaitForSeconds(time);

        anim.SetBool("phase2", true);
    }

    IEnumerator TriggerExplosion(float time)
    {
        yield return new WaitForSeconds(time);

        anim.SetBool("phase3", true);
        hitbox.enabled = true;
        StartCoroutine(DisableHitbox(0.3f));
        Destroy(this.gameObject, animExplosion.length);
    }


    IEnumerator DisableHitbox(float time)
    {
        yield return new WaitForSeconds(time);
        hitbox.enabled = false;
    }
}