using GMTK2019OnlyOne.ECS.Components;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Systems
{
    public static class FireSystem
    {
        public static List<FireComponent> Components = new List<FireComponent>();

        public static void Add(FireComponent C)
        {
            if (Components.Contains(C))
            {
                return;
            }

            Components.Add(C);
        }

        public static void Remove(FireComponent C)
        {
            Components.Remove(C);
        }

        public static void Age()
        {
            List<FireComponent> Remove = new List<FireComponent>();

            foreach(FireComponent F in Components)
            {
                if (F.Age())
                {
                    Remove.Add(F);
                }
            }

            foreach(FireComponent F in Remove)
            {
                F.entity.destroy();

                Components.Remove(F);
            }
        }
    }
}
