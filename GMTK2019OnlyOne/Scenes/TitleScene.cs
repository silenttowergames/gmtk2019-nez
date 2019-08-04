using GMTK2019OnlyOne.ECS.Entities;
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.Scenes
{
    public class TitleScene : Scene
    {
        public override void onStart()
        {
            clearColor = Color.Black;

            Entity Title = EntityFactory.TextWriter(new Vector2(0, 16), "Burn Out");

            base.onStart();
        }

        public override void update()
        {
            base.update();

            if (Input.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                Core.scene = new Level1Scene();
            }
        }
    }
}
