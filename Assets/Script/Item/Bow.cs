using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Item
{
    class Bow : Item
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
                arrow.transform.position = new Vector2(player.transform.position.x, player.transform.position.y-0.2f);
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
