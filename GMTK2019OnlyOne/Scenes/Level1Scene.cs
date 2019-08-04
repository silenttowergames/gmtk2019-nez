using GMTK2019OnlyOne.ECS.Components;
using GMTK2019OnlyOne.ECS.Entities;
using GMTK2019OnlyOne.ECS.Systems;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.Scenes
{
    public class Level1Scene : GameplayScene
    {
        public override void initialize()
        {
            base.initialize();

            ScreenTitle = "       I\n\nFire is the Key";
            MapID = "level1";
        }

        protected override void AddUniqueObjects()
        {
            // Intro room fire bowls
            EntityFactory.FireBowl(new Vector2(32, 32));
            EntityFactory.FireBowl(new Vector2(88, 32));

            // Intro room moss trail
            EntityFactory.Moss(new Vector2(1 * 8, 7 * 8), (BurningComponent B) => EntityFactory.Coin(B.entity.position - new Vector2(4)));
            EntityFactory.Moss(new Vector2(13 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(14 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(14 * 8, 6 * 8));
            EntityFactory.Moss(new Vector2(15 * 8, 6 * 8));
            EntityFactory.Moss(new Vector2(15 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(17 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(17 * 8, 8 * 8));
            Entity InvisibleMoss = EntityFactory.Moss(new Vector2(17 * 8, 9 * 8));
            InvisibleMoss.getComponent<Sprite>().setEnabled(false);

            // Key moss
            EntityFactory.Moss(new Vector2(30 * 8, 16 * 8), (BurningComponent B) => EntityFactory.Item(B.entity.position - new Vector2(4), Items.Key));
            EntityFactory.Moss(new Vector2(30 * 8, 15 * 8));
            EntityFactory.Moss(new Vector2(29 * 8, 16 * 8));

            // Key moss fire
            EntityFactory.FireBowl(new Vector2(28 * 8, 13 * 8));

            // Wood blockage
            EntityFactory.Wood(new Vector2(17 * 8, 10 * 8));

            // Exit
            EntityFactory.Door(new Vector2(3 * 8, 10 * 8), (DoorComponent D) => { Core.scene = new GameplayScene(); }, true);

            // Merchant
            EntityFactory.Merchant(new Vector2(23 * 8, 4 * 8), 1, () =>
            {
                Text T = Core.scene.findEntity("sage-text").getComponent<Text>();
                T.setText(T.text + "\nThanks!");
            });
            EntityFactory.TextWriter(new Vector2(Core.scene.sceneRenderTargetSize.X, 16), "Donate?", "sage-text");

            EntityFactory.Item(new Vector2(23.5f * 8, 13.5f * 8), Items.Torch);

            Player = EntityFactory.Player(new Vector2(56, 16));
        }
    }
}
