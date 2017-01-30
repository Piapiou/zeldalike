using UnityEngine;
using System.Collections;
using Assets.Script.Item;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject inventoryCanvas;
    public GameObject selectionCursor;
    public GameObject[] itemsInventory;

    public GameObject arrowPrefab;
    public GameObject bombPrefab;


    public GameObject player;

    public bool[] unlockedItem;

    public GameObject UIItem1;
    public GameObject UIItem2;
    public Sprite blankSprite;

    private Item[] itemList;

    private int activeObject1 = -1;
    private int activeObject2 = -1;

    public bool inventoryIsActive = false;
    private int selectedItem = 0;
    private int itemPerRow = 4;
    private int numItem = 12;

    private Vector2 originSelection;
    private Vector2 moveSelection;
    
    public GameObject UIHeartPrefab;
    public GameObject UILife;
    private GameObject[] UIHeart;
    private int numHeartDisplayed = 0;
    private Vector2 hearthSize;

    public Vector2 roomSize;
    public GameObject playZone;

    // Use this for initialization
    void Start () {
        inventoryCanvas.SetActive(false);
        originSelection = selectionCursor.transform.localPosition;
        moveSelection = new Vector2(72, -49);
        InitItem();

        UIHeart = new GameObject[20];
        hearthSize = new Vector2(16, -14);
    }
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<playerController>().isDead())
        {
            Time.timeScale = 0.0f;
            UpdateUI();
        } else
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inventoryIsActive = !inventoryIsActive;
                inventoryCanvas.SetActive(inventoryIsActive);
            }

            if (inventoryIsActive)
            {
                Time.timeScale = 0.0f;
                SelectionMovement();
                DisplayItems();
                SelectItem();
            } else
            {
                Time.timeScale = 1.0f;
                CheckActiveItem();
            }
            UpdateUI();

        }
    }
    
    void InitItem()
    {
        itemList = new Item[numItem];

        // Initialisation item Bow.
        Bow bow = new Bow();
        bow.arrowPrefab = arrowPrefab;
        bow.player = player;
        itemList[0] = bow;
        
        // Initialisation item Shield.
        Shield shield = new Shield();
        shield.player = player;
        itemList[1] = shield;

        // Initialisation item Sword.
        Sword sword = new Sword();
        sword.player = player;
        itemList[2] = sword;

        // Initialisation item Bomb.
        Bomb bomb = new Bomb();
        bomb.player = player;
        bomb.bombPrefab = bombPrefab;
        itemList[3] = bomb;

    }

    void SelectionMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedItem -= 4;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedItem += 4;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedItem -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedItem += 1;
        }
        selectedItem = (selectedItem + numItem) % numItem;

        Vector2 posSel = originSelection;
        posSel.x += (selectedItem % itemPerRow) * (moveSelection.x);
        posSel.y += (selectedItem / itemPerRow) * moveSelection.y;
        selectionCursor.transform.localPosition = posSel;
    }

    void DisplayItems()
    {
        for (int i = 0; i < numItem; i++)
        {
            if (itemsInventory[i] != null)
            {
                if (unlockedItem[i])
                {
                    itemsInventory[i].SetActive(true);

                    GameObject active = itemsInventory[i].transform.FindChild("Selected").gameObject;
                    if (activeObject1 == i || activeObject2 == i)
                    {
                        active.SetActive(true);
                    }
                    else
                    {
                        active.SetActive(false);
                    }

                }
                else
                {
                    itemsInventory[i].SetActive(false);
                }
            }
        }
    }
    
   

    void SelectItem()
    {
        if (Input.GetKeyDown(KeyCode.W) && unlockedItem[selectedItem]) {
            if (activeObject1 == selectedItem)
            {
                activeObject1 = -1;
            }
            else
            {
                if (activeObject2 == selectedItem)
                {
                    activeObject2 = activeObject1;
                }
                activeObject1 = selectedItem;
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && unlockedItem[selectedItem])
        {
            if (activeObject2 == selectedItem)
            {
                activeObject2 = -1;
            }
            else
            {
                if (activeObject1 == selectedItem)
                {
                    activeObject1 = activeObject2;
                }
                activeObject2 = selectedItem;
            }
        }
    }

    void CheckActiveItem()
    {
        if (Input.GetKey(KeyCode.W) && activeObject1 != -1)
            itemList[activeObject1].ButtonPressed();

        if (Input.GetKeyDown(KeyCode.W) && activeObject1 != -1)
            itemList[activeObject1].ButtonPressedDown();

        if (Input.GetKeyUp(KeyCode.W) && activeObject1 != -1)
            itemList[activeObject1].ButtonPressedUp();

        if (Input.GetKey(KeyCode.X) && activeObject2 != -1)
            itemList[activeObject2].ButtonPressed();

        if (Input.GetKeyDown(KeyCode.X) && activeObject2 != -1)
            itemList[activeObject2].ButtonPressedDown();

        if (Input.GetKeyUp(KeyCode.X) && activeObject2 != -1)
            itemList[activeObject2].ButtonPressedUp();
    }

    void UpdateUI()
    {
        // Item
        if (activeObject1 != -1)
            UIItem1.GetComponent<Image>().sprite = itemsInventory[activeObject1].transform.FindChild("Sprite").GetComponent<Image>().sprite;
        else
            UIItem1.GetComponent<Image>().sprite = blankSprite;

        if (activeObject2 != -1)
            UIItem2.GetComponent<Image>().sprite = itemsInventory[activeObject2].transform.FindChild("Sprite").GetComponent<Image>().sprite;
        else
            UIItem2.GetComponent<Image>().sprite = blankSprite;
        
        playerController pc = player.GetComponent<playerController>();


        // Health
        while (numHeartDisplayed < pc.maxHealth / 4)
        {
            GameObject heart = Instantiate(UIHeartPrefab);
            heart.transform.SetParent(UILife.transform);
            Vector2 posHeart = new Vector2((hearthSize.x * (numHeartDisplayed % 10)), (hearthSize.y * (numHeartDisplayed / 10)));
            heart.transform.localPosition = posHeart;
            heart.transform.localScale = new Vector2(1, 1);
            UIHeart[numHeartDisplayed++] = heart;
        }

        while (numHeartDisplayed > pc.maxHealth / 4)
        {
            Destroy(UIHeart[numHeartDisplayed--]);
        }

        for (int i = 0; i < numHeartDisplayed; i++)
        {
            Transform fullHeart = UIHeart[i].transform.FindChild("fullHeart");
            fullHeart.GetComponent<Image>().fillAmount = (((float)pc.health / 4.0f)) - (float)i;
        }
    }

    public void moveRoom(int direction)
    {
        Vector3 playZoneMovement = new Vector2(0, 0);
        Vector3 playerMovement = new Vector2(0, 0);
        switch (direction)
        {
            case 0:
                playZoneMovement = new Vector2(0, roomSize.y);
                playerMovement = new Vector2(0, 1);
                break;
            case 1:
                playZoneMovement = new Vector2(roomSize.x, 0);
                playerMovement = new Vector2(1, 0);
                break;
            case 2:
                playZoneMovement = new Vector2(0, -roomSize.y);
                playerMovement = new Vector2(0, -1);
                break;
            case 3:
                playZoneMovement = new Vector2(-roomSize.x, 0);
                playerMovement = new Vector2(-1, 0);
                break;
            default:
                break;
        }
        playZone.transform.position += playZoneMovement;
        player.transform.position += playerMovement;
    }
}
