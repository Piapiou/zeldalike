using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    class Arc : Item
    {
        public GameObject arrowPrefab;
        public GameObject player;

        private GameObject arrow;


        public void ButtonPressed()
        {
            if (arrow == null)
            {
                arrow = GameObject.Instantiate(arrowPrefab);
                arrow.GetComponent<arrowController>().direction = player.GetComponent<playerController>().direction;
                arrow.GetComponent<arrowController>().player = player;
                arrow.transform.position = player.transform.position;
            }
        }

        public void ButtonPressedDown()
        {

        }

        public void ButtonPressedUp()
        {

        }
    }
}
