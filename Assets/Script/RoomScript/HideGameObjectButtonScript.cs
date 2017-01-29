using UnityEngine;
using System.Collections;

public class HideGameObjectButtonScript : MonoBehaviour {

    public GameObject buttonKeep;
    public GameObject[] objectsToHide;

    private bool buttonPushed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (!buttonPushed && buttonKeep.GetComponent<ButtonKeepController>().isPushed)
        {
            hideObjects();
            buttonPushed = true;
        }
        else if (buttonPushed && !buttonKeep.GetComponent<ButtonKeepController>().isPushed)
        {
            showObjects();
            buttonPushed = false;
        }
    }

    void hideObjects()
    {

        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(false);
        }
    }

    void showObjects()
    {

        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(true);
        }
    }
}
