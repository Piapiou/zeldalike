using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Item
{
    

    class Shield : Item
    {
        public GameObject player;

        public void ButtonPressed()
        {

        }

        public void ButtonPressedDown()
        {
            player.GetComponent<playerController>().ShieldUp();
        }

        public void ButtonPressedUp()
        {
            player.GetComponent<playerController>().ShieldDown();
        }
    }
}
