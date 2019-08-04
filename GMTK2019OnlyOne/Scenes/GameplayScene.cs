using GMTK2019OnlyOne.ECS.Components;
using GMTK2019OnlyOne.ECS.Entities;
using GMTK2019OnlyOne.ECS.Systems;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.Scenes
{
    public class GameplayScene : Scene
    {
        protected Entity
            IntroCard,
            Player
        ;

        protected string
            MapID = "test-map",
            ScreenTitle
        ;

        public Timer IntroTimer = new Timer(90);

        public override void initialize()
        {
            clearColor = Game1.BGColor;

            ScreenTitle = "   IIII\nDemo Level";

            ItemPickupSystem.Item = Items.None;
        }

        public override void onStart()
        {
            EntityFactory.Map(Assets.Maps[MapID]);

            AddUniqueObjects();

            EntityFactory.HUDItem();
            EntityFactory.HUDHealth();

            if (Player != null)
            {
                camera.addComponent(new CameraFollowComponent(Player));
            }

            IntroCard = EntityFactory.IntroCard(ScreenTitle);
        }

        protected virtual void AddUniqueObjects()
        {
            EntityFactory.Moss(new Vector2(64, 56));
            EntityFactory.Moss(new Vector2(64, 48));
            EntityFactory.Moss(new Vector2(64, 40));
            EntityFactory.Moss(new Vector2(64, 32));

            EntityFactory.Moss(new Vector2(40, 16), (BurningComponent B) =>
            {
                EntityFactory.Coin(B.entity.position - new Vector2(4));
            });
            EntityFactory.Moss(new Vector2(40, 24));

            EntityFactory.Wood(new Vector2(56, 40));

            EntityFactory.Door(new Vector2(24, 8), (DoorComponent D) => { });

            EntityFactory.Door(new Vector2(64, 8), (DoorComponent D) => {
                Core.scene = new GameplayScene();
            }, true);

            Player = EntityFactory.Player(new Vector2(24));
            //EntityFactory.Enemy();
            EntityFactory.FireBowl(new Vector2(16));

            EntityFactory.Item(new Vector2(48, 128), Items.Key);
            EntityFactory.Item(new Vector2(32, 24), Items.Torch);

            EntityFactory.Merchant(new Vector2(24, 4) * new Vector2(8), 1, () =>
            {
                Text T = Core.scene.findEntity("sage-text").getComponent<Text>();
                T.setText(T.text + "\nThanks!");
            });
            EntityFactory.TextWriter(new Vector2(Core.scene.sceneRenderTargetSize.X, 16), "Donate?", "sage-text");
        }

        public override void update()
        {
            if (IntroTimer.GetFinished())
            {
                TimeSystem.update();

                if (IntroCard != null)
                {
                    IntroCard.destroy();
                    IntroCard = null;
                }
            }

            base.update();

            ItemPickupSystem.Update();
            HUDPositionSystem.Update();
            BurningSystem.Update();
            MoneySystem.Update();
        }
    }
}
