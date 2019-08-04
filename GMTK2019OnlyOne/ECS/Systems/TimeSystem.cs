using Microsoft.Xna.Framework.Input;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Systems
{
    public static class TimeSystem
    {
        public static int Direction;

        public static void update()
        {
            Direction = -1;

            if (Input.isKeyPressed(Keys.Right))
            {
                Direction = 1;
            }

            if (Input.isKeyPressed(Keys.Left))
            {
                Direction = 3;
            }

            if (Input.isKeyPressed(Keys.Down))
            {
                Direction = 2;
            }

            if (Input.isKeyPressed(Keys.Up))
            {
                Direction = 0;
            }
        }
    }
}
