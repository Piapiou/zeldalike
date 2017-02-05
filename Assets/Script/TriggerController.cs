using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour
{

    public bool isActivated = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            isActivated = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            isActivated = false;
        }
    }
}
