using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Item
{
    class Bomb : Item
    {

        public GameObject player;
        public GameObject bombPrefab;

        private GameObject bomb;

        public void ButtonPressed()
        {

        }

        public void ButtonPressedDown()
        {

            if (bomb == null)
            {
                bomb = GameObject.Instantiate(bombPrefab);
                bomb.transform.position = player.transform.position;
            }
        }

        public void ButtonPressedUp()
        {

        }
    }
}
