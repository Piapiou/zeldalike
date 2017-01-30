using UnityEngine;
using System.Collections;

public class TriggerDoorScript : MonoBehaviour {
    
    public GameObject[] switchs;
    public GameObject[] doors;
    private bool triggered = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (!triggered)
        {
            triggered = true;
            for (int i = 0; i < switchs.Length; i++)
            {
                triggered &= switchs[i].GetComponent<SwitchController>().isOn;
            }

            if (triggered)
            {
                OpenDoors();
            }

        }
    }

    void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(false);
        }
    }
}
