using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class CameraFollowComponent : Component, IUpdatable
    {
        public Entity Follow;

        public CameraFollowComponent(Entity E)
        {
            Follow = E;
        }

        public void update()
        {
            if (Follow == null)
            {
                return;
            }

            entity.position = Follow.position;

            entity.position = new Vector2(
                (float)(Math.Floor(entity.position.X / Core.scene.sceneRenderTargetSize.X) * Core.scene.sceneRenderTargetSize.X) + (Core.scene.sceneRenderTargetSize.X / 2),
                (float)(Math.Floor(entity.position.Y / Core.scene.sceneRenderTargetSize.Y) * Core.scene.sceneRenderTargetSize.Y) + (Core.scene.sceneRenderTargetSize.Y / 2)
            );
        }
    }
}
