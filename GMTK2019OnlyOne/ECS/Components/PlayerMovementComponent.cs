﻿using GMTK2019OnlyOne.ECS.Entities;
using GMTK2019OnlyOne.ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class PlayerMovementComponent : MovementComponent
    {
        Timer DeathTimer = new Timer(60);

        Vector2 OriginalPos;

        public PlayerMovementComponent(Vector2 _OriginalPos)
        {
            OriginalPos = _OriginalPos;
        }

        protected override Vector2 GetDelta()
        {
            Vector2 Delta = new Vector2();

            if (TimeSystem.Direction == 1)
            {
                Delta += new Vector2(8, 0);
            }

            if (TimeSystem.Direction == 3)
            {
                Delta -= new Vector2(8, 0);
            }

            if (TimeSystem.Direction == 2)
            {
                Delta += new Vector2(0, 8);
            }

            if (TimeSystem.Direction == 0)
            {
                Delta -= new Vector2(0, 8);
            }

            return Delta;
        }

        protected override void Dead()
        {
            if (DeathTimer.GetFinished())
            {
                if (ItemPickupSystem.EmptyItem != null)
                {
                    ItemPickupSystem.EmptyItem.Item = ItemPickupSystem.Item;
                    ItemPickupSystem.EmptyItem.entity.position = entity.position;
                    ItemPickupSystem.EmptyItem.entity.addComponent(Animations.GetItemSprite(ItemPickupSystem.Item));
                }

                ItemPickupSystem.Item = Items.None;

                entity.destroy();

                CameraFollowComponent CFC = Core.scene.camera.getComponent<CameraFollowComponent>();

                CFC.Follow = EntityFactory.Player(OriginalPos);

                ItemPickupSystem.FullUpdate();
            }
        }

        protected override void DidMove()
        {
            ItemPickupSystem.ModifierChange();
            FireSystem.Age();
        }

        protected override void TouchCollider(Collider C)
        {
            // Attempt to light your torch
            FireLightComponent F = C.getComponent<FireLightComponent>();

            if ((ItemPickupSystem.Item == Items.Torch || ItemPickupSystem.Item != Items.TorchLit) && F != null)
            {
                ItemPickupSystem.Modifier = F.FireLimit;

                ItemPickupSystem.UpdateText();
            }

            // Attempt to open a door
            DoorComponent D = C.getComponent<DoorComponent>();

            if (D != null)
            {
                D.TryOpen();
            }

            // Attempt to purchase
            MerchantComponent M = C.getComponent<MerchantComponent>();

            if (M != null)
            {
                M.TryBuy();
            }
        }
    }
}
