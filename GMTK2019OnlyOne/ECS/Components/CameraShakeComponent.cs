using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class CameraShakeComponent : Component, IUpdatable
    {
        Timer ShakeTimer = new Timer(10);

        public void update()
        {
            if (ShakeTimer.GetFinished())
            {
                this.removeComponent();
            }

            entity.position += new Vector2(
                Numbers.Random(2),
                Numbers.Random(2)
            );
        }
    }
}
