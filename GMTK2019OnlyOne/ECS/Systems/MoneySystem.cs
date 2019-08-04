using GMTK2019OnlyOne.ECS.Components;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Systems
{
    public static class MoneySystem
    {
        static List<MoneyComponent> Components = new List<MoneyComponent>();

        public static void Add(MoneyComponent C)
        {
            if (Components.Contains(C))
            {
                return;
            }

            Components.Add(C);
        }

        public static void Remove(MoneyComponent C)
        {
            Components.Remove(C);
        }

        public static void Update()
        {
            Entity Player = Core.scene.findEntity("player");
            RectangleF PlayerR = new RectangleF(
                Player.position.X,
                Player.position.Y,
                8,
                8
            );

            foreach(MoneyComponent M in Components)
            {
                RectangleF MR = new RectangleF(
                    M.entity.position.X,
                    M.entity.position.Y,
                    8,
                    8
                );

                if (!PlayerR.intersects(MR))
                {
                    continue;
                }

                M.entity.destroy();

                ItemPickupSystem.Money++;
            }
        }
    }
}
