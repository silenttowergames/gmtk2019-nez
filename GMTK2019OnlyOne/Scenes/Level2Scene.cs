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
            EntityFactory.FireBowl(new Vector2(1 * 8, 16 * 8));
            EntityFactory.Item(new Vector2(3 * 8, 13 * 8), Items.Torch);
            EntityFactory.Moss(new Vector2(4 * 8, 16 * 8));
            EntityFactory.Moss(new Vector2(5 * 8, 16 * 8));
            EntityFactory.Moss(new Vector2(5 * 8, 15 * 8));
            EntityFactory.Moss(new Vector2(5 * 8, 14 * 8));
            EntityFactory.Moss(new Vector2(5 * 8, 13 * 8));

            Player = EntityFactory.Player(new Vector2(2 * 8, 13 * 8));
        }
    }
}
