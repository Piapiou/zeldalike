using UnityEngine;
using System.Collections;

public class ButtonDoorScript : MonoBehaviour {

    public GameObject[] buttonsOnce;
    public GameObject[] buttonsKeep;
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
            for (int i = 0; i < buttonsOnce.Length; i++)
            {
                triggered &= buttonsOnce[i].GetComponent<ButtonOnceController>().isPushed;
            }

            for (int i = 0; i < buttonsKeep.Length; i++)
            {
                triggered &= buttonsKeep[i].GetComponent<ButtonKeepController>().isPushed;
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
