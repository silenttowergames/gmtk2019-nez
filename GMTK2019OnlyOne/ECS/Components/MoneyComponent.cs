using GMTK2019OnlyOne.ECS.Systems;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class MoneyComponent : Component
    {
        public override void onAddedToEntity()
        {
            MoneySystem.Add(this);
        }

        public override void onRemovedFromEntity()
        {
            MoneySystem.Remove(this);
        }
    }
}
