using GMTK2019OnlyOne.ECS.Entities;
using GMTK2019OnlyOne.ECS.Systems;
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.Scenes
{
    public class CreditsScene : Scene
    {
        Entity T;

        Timer GoBackTimer = new Timer(15 * 60);

        public override void onStart()
        {
            clearColor = Color.Black;

            string Rating = "Any% Run";

            if (ItemPickupSystem.Money == 2)
            {
                Rating = "Greed Run";
            }

            if(ItemPickupSystem.TotalDonations >= 2)
            {
                Rating = "Generous Run";
            }

            T = EntityFactory.TextWriter(new Microsoft.Xna.Framework.Vector2(0, Core.scene.sceneRenderTargetSize.Y + 2),
                "Burn Out\n\nGMTK Game Jam\n2019 \"Only One\"\n\n\nSilent Tower\nGames LLC\n\n\nYour Rating:\n" + Rating
            );

            ItemPickupSystem.Money = ItemPickupSystem.TotalDonations = 0;
        }

        public override void update()
        {
            base.update();

            T.position -= new Vector2(0, 0.2f);

            if (GoBackTimer.GetFinished())
            {
                Core.scene = new TitleScene();
            }
        }
    }
}
