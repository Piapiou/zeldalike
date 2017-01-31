using UnityEngine;
using System.Collections;

public class VaatiController : MonoBehaviour {

    public GameObject player;
    public GameObject ballPrefabs;
    public EnemyMovement move;

    public GameObject[] vaatiTargets;
    public int currentTargetPosition = 4;
    private int numberPositionSwitch = 0;
    public float speed = 1.0f;

    private GameObject ball;
    public float ballSpeed = 1.5f;
    private int numberSendBack = 0;

    public EnemyHealth life;
    public float vulnerableTime = 5.0f;

    public int contactDamage;
    public int contactKnockback;

    public Animator anim;

    private Vector2 vel;

	// Use this for initialization
	void Start () {
        vel = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {


	    if (ball == null && !life.isVulnerable && life.lifePoints > 0)
        {
            if ((vaatiTargets[currentTargetPosition].transform.position - transform.position).sqrMagnitude > 0.05)
            {
                vel = (vaatiTargets[currentTargetPosition].transform.position - transform.position).normalized * speed;
            } else
            {
                vel = new Vector2(0, 0);
                if (numberPositionSwitch < 3)
                {
                    int previousPosition = currentTargetPosition;
                    while (currentTargetPosition == previousPosition)
                    {
                        currentTargetPosition = (int)(Random.value * 6);
                    }
                    numberPositionSwitch++;
                } else
                {
                    numberPositionSwitch = 0;
                    CreateBall();
                }
            }
        }
        move.setVelocity(vel);
    }

    public void SendBackBall()
    {
        if (numberSendBack < 3)
        {
            ball.GetComponent<VaatiBallController>().moveToPlayer = true;
            ball.GetComponent<VaatiBallController>().speed *= 2;
            ball.layer = 22;
            numberSendBack++;
        } else
        {
            Destroy(ball);
            numberSendBack = 0;
            
            MakeVulnerable();
        }
    }

    void MakeVulnerable()
    {
        life.isVulnerable = true;
        anim.SetBool("isVulnerable", true);
        StartCoroutine(MakeImmuneback(vulnerableTime));
    }

    IEnumerator MakeImmuneback(float time)
    {
        yield return new WaitForSeconds(time);
        life.isVulnerable = false;
        anim.SetBool("isVulnerable", false);
    }

    void CreateBall()
    {
        numberSendBack = 0;
        ball = Instantiate(ballPrefabs);
        ball.GetComponent<VaatiBallController>().player = player;
        ball.GetComponent<VaatiBallController>().Vaati = gameObject;
        ball.transform.position = transform.position;
        ball.GetComponent<VaatiBallController>().speed = ballSpeed;
    }
}
