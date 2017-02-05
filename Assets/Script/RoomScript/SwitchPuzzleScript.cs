using UnityEngine;
using System.Collections;

public class SwitchPuzzleScript : MonoBehaviour {

    public GameObject[] badSwitch;
    public GameObject[] goodSwitch;
    public GameObject theDoor;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool trigger = true;
        for (int i = 0; trigger && i < badSwitch.Length; i++)
        {
            trigger &= !badSwitch[i].GetComponent<SwitchController>().isOn;
        }

        for (int i = 0; trigger && i < goodSwitch.Length; i++)
        {
            trigger &= goodSwitch[i].GetComponent<SwitchController>().isOn;
        }

        if (trigger)
        {
            theDoor.SetActive(false);
        }
    }
}
