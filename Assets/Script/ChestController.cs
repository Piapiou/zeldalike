using UnityEngine;
using System.Collections;

public class ChestController : MonoBehaviour {

    public Animator anim;
    public GameController gameController;
    public int unlockedItem;
    public Sprite unlockedItemSprite;
    public SpriteRenderer objectSprite;
    public bool isOpen = false;

    private Sprite blankSprite;

	// Use this for initialization
	void Start () {
        blankSprite = objectSprite.sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        Debug.Log(coll.contacts[0].normal.y);
        if (!isOpen && coll.collider.tag == "Player" && coll.contacts[0].normal.y > 0.7 && Input.GetKey(KeyCode.W))
        {
            isOpen = true;
            anim.SetBool("opened", true);
            gameController.unlockedItem[unlockedItem] = true;
            objectSprite.sprite = unlockedItemSprite;
            Time.timeScale = 0.0f;
            StartCoroutine(deleteSprite(2.0f));
        }
    }

    IEnumerator deleteSprite(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1.0f;
        objectSprite.sprite = blankSprite;
    }
}
