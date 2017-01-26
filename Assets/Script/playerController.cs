using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    
    public float speed = 1.0f;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;

    public GameObject UIHeartPrefab;
    public GameObject UILife;
    private GameObject[] UIHeart;
    private int numHeartDisplayed = 0;
    private Vector2 hearthSize;

    public int maxHealth = 16;
    public int health = 16;

    public int direction;

    // Use this for initialization
    void Start () {
        UIHeart = new GameObject[20];
        hearthSize = new Vector2(16, -14);
	}
	
	// Update is called once per frame
	void Update () {

        UpdateMove();
        DisplayHealth();
    }

    void UpdateMove()
    {
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
        {
            direction = 3;
            anim.SetInteger("Direction", 3);
        }
        else if (vel.x < 0)
        {
            direction = 2;
            anim.SetInteger("Direction", 2);
        }
        else if (vel.y > 0)
        {
            direction = 0;
            anim.SetInteger("Direction", 0);
        }
        else if (vel.y < 0)
        {
            direction = 1;
            anim.SetInteger("Direction", 1);
        }
        rb.velocity = vel;
    }

    void DisplayHealth()
    {
        while (numHeartDisplayed < maxHealth/4)
        {
            GameObject heart = Instantiate(UIHeartPrefab);
            heart.transform.SetParent(UILife.transform);
            Vector2 posHeart = new Vector2((hearthSize.x * (numHeartDisplayed % 10)), (hearthSize.y * (numHeartDisplayed / 10)));
            heart.transform.localPosition = posHeart;
            heart.transform.localScale = new Vector2(1, 1);
            UIHeart[numHeartDisplayed++] = heart;
        }

        while (numHeartDisplayed > maxHealth / 4)
        {
            Destroy(UIHeart[numHeartDisplayed--]);
        }

        for (int i = 0; i < numHeartDisplayed; i++)
        {
            Transform fullHeart = UIHeart[i].transform.FindChild("fullHeart");
            fullHeart.GetComponent<Image>().fillAmount = (((float)health / 4.0f)) - (float)i;
        }
    }
}
