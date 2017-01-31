using UnityEngine;
using System.Collections;

public class VaatiController : MonoBehaviour {

    public GameObject player;
    public GameObject ballPrefabs;
    public Rigidbody2D rb;

    public GameObject[] vaatiTargets;
    public int currentTargetPosition = 4;
    private int numberPositionSwitch = 0;
    public float speed = 1.0f;

    private GameObject ball;
    private int numberSendBack = 0;

    public int contactDamage;
    public int contactKnockback;

    private Vector2 vel;

	// Use this for initialization
	void Start () {
        vel = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(currentTargetPosition);
        Debug.Log((transform.position - vaatiTargets[currentTargetPosition].transform.position));
	    if (ball == null)
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
        rb.velocity = vel;
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

    }

    IEnumerator MakeImmuneback(float time)
    {

        yield return new WaitForSeconds(time);
    }

    void CreateBall()
    {
        ball = Instantiate(ballPrefabs);
        ball.GetComponent<VaatiBallController>().player = player;
        ball.GetComponent<VaatiBallController>().Vaati = gameObject;
        ball.transform.position = transform.position;
    }
}
