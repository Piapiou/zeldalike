using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Item
{
    class Sword : Item
    {
        public GameObject player;

        public void ButtonPressed()
        {

        }

        public void ButtonPressedDown()
        {
            player.GetComponent<playerController>().Attack();
        }

        public void ButtonPressedUp()
        {

        }
    }
}
