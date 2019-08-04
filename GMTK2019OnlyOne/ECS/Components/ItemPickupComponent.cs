using GMTK2019OnlyOne.ECS.Systems;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class ItemPickupComponent : Component, IUpdatable
    {
        public Items Item;

        public bool Touching = false;

        public ItemPickupComponent(Items _Item = Items.None)
        {
            Item = _Item;
        }

        public override void onAddedToEntity()
        {
            ItemPickupSystem.Add(this);
        }

        public override void onRemovedFromEntity()
        {
            ItemPickupSystem.Remove(this);
        }

        public void update()
        {
            Sprite<Items> S = entity.getComponent<Sprite<Items>>();

            if (S == null)
            {
                return;
            }

            S.play(Item);
            
            S.enabled = Item != Items.None;

            if (!S.enabled)
            {
                ItemPickupSystem.EmptyItem = this;
            }
        }
    }
}
