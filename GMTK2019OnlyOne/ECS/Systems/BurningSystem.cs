using GMTK2019OnlyOne.ECS.Components;
using GMTK2019OnlyOne.ECS.Entities;
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Systems
{
    public static class BurningSystem
    {
        static List<BurningComponent> Components = new List<BurningComponent>();

        public static void Add(BurningComponent C)
        {
            if (Components.Contains(C))
            {
                return;
            }

            Components.Add(C);
        }

        public static void Remove(BurningComponent C)
        {
            Components.Remove(C);
        }

        public static void Update()
        {
            List<Vector2> Sources = new List<Vector2>();

            foreach(FireComponent F in FireSystem.Components)
            {
                if (F.LifetimeLimit == F.Lifetime)
                {
                    continue;
                }

                Sources.Add(F.entity.position);
            }

            BurnWood(Sources);

            if (ItemPickupSystem.Item == Items.TorchLit)
            {
                Sources.Add(Core.scene.findEntity("player").position);
            }

            if(Sources.Count <= 0)
            {
                return;
            }

            BurnMoss(Sources);
        }

        private static void BurnWood(List<Vector2> Sources)
        {
            BurnAbstract(Sources, true);
        }

        private static void BurnMoss(List<Vector2> Sources)
        {
            BurnAbstract(Sources, false);
        }

        private static void BurnAbstract(List<Vector2> Sources, bool Tough)
        {
            foreach (BurningComponent B in Components)
            {
                if (B.Tough != Tough)
                {
                    continue;
                }

                foreach (Vector2 Source in Sources)
                {
                    Vector2 Difference = Source - B.entity.position;

                    if (Math.Abs(Difference.X) > 8 || Math.Abs(Difference.Y) > 8 || (Difference.X != 0 && Difference.Y != 0))
                    {
                        continue;
                    }

                    Vector2 P = B.entity.position - new Vector2(4);

                    if (B.OnBurn != null)
                    {
                        B.OnBurn(B);
                    }

                    B.entity.destroy();

                    EntityFactory.Fire(P);

                    break;
                }
            }
        }
    }
}
