using UnityEngine;
using System.Collections;

public class TriggerBossScript : MonoBehaviour {

    public GameObject Trigger;
    public GameObject Boss;
    public GameObject Door;

    private int phase = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (phase == 0 && Trigger.GetComponent<TriggerController>().isActivated)
        {
            phase++;
            Door.SetActive(true);
            Boss.SetActive(true);
        }
        if (phase == 1 && Boss == null)
        {
            phase++;
            Door.SetActive(false);
        }
	}
}
