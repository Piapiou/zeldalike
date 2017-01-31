using UnityEngine;
using System.Collections;

public class MultipleEnemyDoorScript : MonoBehaviour {

    public GameObject[] octorok;
    public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (door.activeSelf)
        {
            bool octo = false;
            for (int i = 0; i < octorok.Length; i++)
            {
                octo |= (octorok[i] != null);
            }

            door.SetActive(octo);
        }
	}
}
