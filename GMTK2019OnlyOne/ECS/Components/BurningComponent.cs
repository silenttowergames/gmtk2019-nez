using GMTK2019OnlyOne.ECS.Systems;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class BurningComponent : Component
    {
        public Action<BurningComponent> OnBurn;

        public bool Tough;

        public BurningComponent(Action<BurningComponent> _OnBurn = null, bool _Tough = false)
        {
            OnBurn = _OnBurn;

            Tough = _Tough;
        }

        public override void onAddedToEntity()
        {
            BurningSystem.Add(this);
        }

        public override void onRemovedFromEntity()
        {
            BurningSystem.Remove(this);
        }
    }
}
