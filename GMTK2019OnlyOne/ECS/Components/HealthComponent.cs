using GMTK2019OnlyOne.ECS.Entities;
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class HealthComponent : Component
    {
        public int Limit;

        public HealthComponent(int _Limit = 5)
        {
            Limit = _Limit;
        }

        public void Hurt(int Hit = 1)
        {
            Limit -= Hit;

            EntityFactory.Blood(entity.position - new Vector2(4));

            Game1.ScreenShake();
        }
    }
}
