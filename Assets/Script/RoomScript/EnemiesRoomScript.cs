using UnityEngine;
using System.Collections;

public class EnemiesRoomScript : MonoBehaviour {

    public GameObject Trigger;
    public GameObject[] Enemies;
    public GameObject[] Doors;

    private int phase = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 0 && Trigger.GetComponent<TriggerController>().isActivated)
        {
            phase++;
            for (int i = 0; i < Doors.Length; i++) Doors[i].SetActive(true);
            for (int i = 0; i < Enemies.Length; i++) Enemies[i].SetActive(true);
        }

        bool enemiesDead = true;
        for (int i = 0; i < Enemies.Length; i++) enemiesDead &= Enemies[i] == null;

        if (phase == 1 && enemiesDead)
        {
            phase++;
            for (int i = 0; i < Doors.Length; i++) Doors[i].SetActive(false);
        }
    }
}
