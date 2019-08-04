using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class BlackoutComponent : RenderableComponent
    {
        public override float width => Core.scene.sceneRenderTargetSize.X;

        public override float height => Core.scene.sceneRenderTargetSize.Y;

        public override void render(Graphics graphics, Camera camera)
        {
            graphics.batcher.drawRect(
                new RectangleF(
                    -1,
                    -1,
                    Core.scene.sceneRenderTargetSize.X + 1,
                    Core.scene.sceneRenderTargetSize.Y + 1
                ),
                Color.Black
            );
        }
    }
}
