using GMTK2019OnlyOne.ECS.Systems;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class FireComponent : Component
    {
        public int LifetimeLimit, Lifetime;

        public FireComponent(int _Lifetime)
        {
            LifetimeLimit = Lifetime = _Lifetime;
        }

        public override void onAddedToEntity()
        {
            FireSystem.Add(this);
        }

        public override void onRemovedFromEntity()
        {
            FireSystem.Remove(this);
        }

        public bool Age()
        {
            return --Lifetime <= 0;
        }
    }
}
