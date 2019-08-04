using GMTK2019OnlyOne.ECS.Components;
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Systems
{
    public enum HP
    {
        Alive,
        Dead
    }

    public static class HUDPositionSystem
    {
        static List<HUDPositionComponent> Components = new List<HUDPositionComponent>();

        public static void Add(HUDPositionComponent C)
        {
            if (Components.Contains(C))
            {
                return;
            }

            Components.Add(C);
        }

        public static void Remove(HUDPositionComponent C)
        {
            Components.Remove(C);
        }

        public static void Update()
        {
            Entity U = Core.scene.findEntity("huditem");

            foreach(HUDPositionComponent H in Components)
            {
                H.entity.position = H.OrigPos + Core.scene.camera.position - (Core.scene.sceneRenderTargetSize.ToVector2() / 2);
            }
        }
    }
}
