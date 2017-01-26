using UnityEngine;
using System.Collections;
using Assets.Script;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject inventoryCanvas;
    public GameObject selectionCursor;
    public GameObject[] itemsInventory;

    public GameObject arrowPrefab;

    public GameObject player;

    public bool[] unlockedItem;

    private Item[] itemList;

    private int activeObject1 = -1;
    private int activeObject2 = -1;

    private bool inventoryIsActive = false;
    private int selectedItem = 0;
    private int itemPerRow = 4;
    private int numItem = 12;

    private Vector2 originSelection;
    private Vector2 moveSelection;

    // Use this for initialization
    void Start () {
        inventoryCanvas.SetActive(false);
        originSelection = selectionCursor.transform.localPosition;
        moveSelection = new Vector2(72, -49);
        InitItem();
    }
	
	// Update is called once per frame
	void Update () {
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

    }
    
    void InitItem()
    {
        itemList = new Item[numItem];
        for (int i = 0; i < numItem; i++)
        {
            unlockedItem[i] = false;
        } 

        // Initialisation item Arc.
        Arc arc = new Arc();
        arc.arrowPrefab = arrowPrefab;
        arc.player = player;
        itemList[0] = arc;

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
}
