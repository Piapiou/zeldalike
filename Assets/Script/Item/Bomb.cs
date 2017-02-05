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
                int dir = player.GetComponent<playerController>().direction;
                Vector2 pos = player.transform.position;
                Debug.Log(dir);
                switch (dir)
                {
                    case 0:
                        pos += new Vector2(0.0f, 0.08f);
                        break;
                    case 1:
                        pos += new Vector2(0.4f, -0.32f);
                        break;
                    case 2:
                        pos += new Vector2(0.0f, -0.72f);
                        break;
                    case 3:
                        pos += new Vector2(-0.4f, -0.32f);
                        break;
                    default:
                        break;
                }
                bomb.transform.position = pos;
            }
        }

        public void ButtonPressedUp()
        {

        }
    }
}
