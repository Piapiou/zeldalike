using UnityEngine;
using System.Collections;

public class BombRoomScript : MonoBehaviour {

    public GameObject trigger;
    public GameObject resetButton;
    public GameObject chest;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        

        if (!chest.GetComponent<ChestController>().isOpen && trigger.GetComponent<TriggerController>().isActivated)
        {
            chest.SetActive(false);
        }

        if (!chest.activeSelf && resetButton.GetComponent<ButtonKeepController>().isPushed)
        {
            chest.SetActive(true);
        }
	}
}
