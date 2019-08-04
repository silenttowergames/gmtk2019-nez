using GMTK2019OnlyOne.ECS.Systems;
using GMTK2019OnlyOne.Scenes;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class HUDCoinsComponent : RenderableComponent
    {
        public override float width => 8;

        public override float height => 8;

        Sprite<Animation> S;

        public override void onAddedToEntity()
        {
            S = new Sprite<Animation>();
            S.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(7, 0), new Vector2(7, 1)));
            S.layerDepth = 0.1f;
            S.entity = entity;
        }

        public override void render(Graphics graphics, Camera camera)
        {
            GameplayScene Sc = (GameplayScene)Core.scene;

            if (ItemPickupSystem.Money <= 0 || Sc != null && !Sc.IntroTimer.IsFinished())
            {
                return;
            }

            S.play(Animation.Idle);

            S.localOffset = new Vector2(8, 0);

            for (int Amount = 0; Amount < ItemPickupSystem.Money; Amount++)
            {
                S.localOffset -= new Vector2(8, 0);

                S.render(graphics, camera);
            }
        }
    }
}
