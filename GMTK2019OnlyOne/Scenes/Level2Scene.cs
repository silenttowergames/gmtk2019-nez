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
    public class Level2Scene : GameplayScene
    {
        public override void initialize()
        {
            base.initialize();

            ScreenTitle = "   II\n\nKindling";
            MapID = "level2";
        }

        protected override void AddUniqueObjects()
        {
            // First room
            EntityFactory.FireBowl(new Vector2(1 * 8, 16 * 8));
            EntityFactory.Item(new Vector2(3 * 8, 13 * 8), Items.Torch);
            //EntityFactory.Moss(new Vector2(4 * 8, 16 * 8));
            EntityFactory.Moss(new Vector2(5 * 8, 15 * 8));
            EntityFactory.Moss(new Vector2(4 * 8, 15 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 16 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 15 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 14 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 16 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 17 * 8));
            EntityFactory.Wood(new Vector2(6 * 8, 13 * 8));
            EntityFactory.Wood(new Vector2(3 * 8, 16 * 8));

            EntityFactory.Wood(new Vector2(7 * 8, 17 * 8));
            EntityFactory.Wood(new Vector2(8 * 8, 17 * 8));

            // Second room
            EntityFactory.FireBowl(new Vector2(9 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 2 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 3 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 4 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(7 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(8 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(9 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(10 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(11 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(11 * 8, 6 * 8));
            EntityFactory.Moss(new Vector2(12 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(12 * 8, 6 * 8));
            EntityFactory.Moss(new Vector2(12 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(13 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(13 * 8, 6 * 8));
            EntityFactory.Moss(new Vector2(13 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(14 * 8, 5 * 8));
            EntityFactory.Moss(new Vector2(14 * 8, 6 * 8));
            EntityFactory.Moss(new Vector2(14 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(15 * 8, 6 * 8));
            EntityFactory.Moss(new Vector2(15 * 8, 13 * 8));
            EntityFactory.Moss(new Vector2(14 * 8, 13 * 8));
            EntityFactory.Moss(new Vector2(15 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 7 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 8 * 8));
            Entity InvisibleMoss0 = EntityFactory.Moss(new Vector2(16 * 8, 9 * 8));
            InvisibleMoss0.getComponent<Sprite>().setEnabled(false);
            EntityFactory.Moss(new Vector2(16 * 8, 10 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 11 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 12 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 13 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 14 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 15 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 16 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 17 * 8));
            Entity InvisibleMoss1 = EntityFactory.Moss(new Vector2(16 * 8, 18 * 8));
            InvisibleMoss1.getComponent<Sprite>().setEnabled(false);
            EntityFactory.Moss(new Vector2(16 * 8, 19 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 20 * 8));
            EntityFactory.Moss(new Vector2(16 * 8, 21 * 8));
            EntityFactory.Moss(new Vector2(15 * 8, 21 * 8));
            EntityFactory.Moss(new Vector2(14 * 8, 21 * 8));
            EntityFactory.Moss(new Vector2(14 * 8, 22 * 8));

            EntityFactory.Wood(new Vector2(15 * 8, 4 * 8));
            EntityFactory.Wood(new Vector2(15 * 8, 5 * 8));

            EntityFactory.Wood(new Vector2(9 * 8, 22 * 8));
            EntityFactory.Wood(new Vector2(9 * 8, 23 * 8));

            EntityFactory.FireBowl(new Vector2(8 * 8, 25 * 8));
            EntityFactory.Wood(new Vector2(7 * 8, 25 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 25 * 8));
            EntityFactory.Moss(new Vector2(6 * 8, 24 * 8));
            EntityFactory.Moss(new Vector2(7 * 8, 24 * 8));
            EntityFactory.Moss(new Vector2(7 * 8, 24 * 8));
            EntityFactory.Moss(new Vector2(8 * 8, 24 * 8));
            EntityFactory.Moss(new Vector2(8 * 8, 23 * 8));

            EntityFactory.FireBowl(new Vector2(1 * 8, 20 * 8));

            EntityFactory.Wood(new Vector2(7 * 8, 2 * 8));
            EntityFactory.Moss(new Vector2(1 * 8, 4 * 8));
            EntityFactory.Moss(new Vector2(1 * 8, 3 * 8));
            EntityFactory.Moss(new Vector2(2 * 8, 3 * 8));
            EntityFactory.Moss(new Vector2(1 * 8, 2 * 8), (BurningComponent B) => EntityFactory.Coin(B.entity.position - new Vector2(4)));

            EntityFactory.Door(new Vector2(23 * 8, 1 * 8), (DoorComponent D) => { Core.scene = new Level2Scene(); });

            // Merchant
            EntityFactory.Merchant(new Vector2(23 * 8, 13 * 8), 1, () =>
            {
                Text T = Core.scene.findEntity("sage-text").getComponent<Text>();
                T.setText(T.text + "\nThanks!");
            });
            EntityFactory.TextWriter(new Vector2(Core.scene.sceneRenderTargetSize.X, 16 + Core.scene.sceneRenderTargetSize.Y), "Donate?", "sage-text");

            Player = EntityFactory.Player(new Vector2(2 * 8, 13 * 8));
        }
    }
}
