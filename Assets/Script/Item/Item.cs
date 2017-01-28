using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Item
{
    interface Item
    {
        void ButtonPressed();
        void ButtonPressedUp();
        void ButtonPressedDown();
    }
}
