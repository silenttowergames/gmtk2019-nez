using GMTK2019OnlyOne.ECS.Systems;
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class HUDPositionComponent : Component
    {
        public Vector2 OrigPos;

        public HUDPositionComponent(Vector2 _OrigPos)
        {
            OrigPos = _OrigPos;
        }

        public override void onAddedToEntity()
        {
            HUDPositionSystem.Add(this);
        }

        public override void onRemovedFromEntity()
        {
            HUDPositionSystem.Remove(this);
        }
    }
}
