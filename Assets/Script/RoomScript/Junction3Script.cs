using UnityEngine;
using System.Collections;

public class Junction3Script : MonoBehaviour {

    public GameObject[] buttons;
    public GameObject[] itemsToActive;
    public GameObject[] doors;
    private bool[] activated;


    // Use this for initialization
    void Start() {
        activated = new bool[4];
        for (int i =0; i < 4; i++) activated[i] = false;
	}

    // Update is called once per frame
    void Update() {
        
        if (!activated[0] && buttons[0].GetComponent<ButtonOnceController>().isPushed)
        {
            activated[0] = true;
            doors[0].SetActive(false);
            doors[1].SetActive(false);
        }
        

        if (!activated[1] && buttons[1].GetComponent<ButtonOnceController>().isPushed)
        {
            activated[1] = true;
            itemsToActive[1].SetActive(true);
            itemsToActive[2].SetActive(true);
        }


        if (!activated[2] && buttons[2].GetComponent<ButtonOnceController>().isPushed)
        {
            activated[2] = true;
            itemsToActive[0].SetActive(true);
        }


        if (!activated[3] && buttons[3].GetComponent<ButtonOnceController>().isPushed)
        {
            activated[3] = true;
            itemsToActive[3].SetActive(true);
        }
        
    }
}
