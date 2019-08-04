using GMTK2019OnlyOne.ECS.Systems;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class DoorComponent : Component
    {
        Action<DoorComponent> OnEnter;

        public bool Locked;

        public DoorComponent(Action<DoorComponent> _OnEnter, bool _Locked = false)
        {
            OnEnter = _OnEnter;
            Locked = _Locked;
        }

        public void TryOpen()
        {
            if (
                OnEnter == null
                ||
                (Locked && ItemPickupSystem.Item != Items.Key)
            )
            {
                Game1.ScreenShake();

                return;
            }

            OnEnter(this);
        }
    }
}
