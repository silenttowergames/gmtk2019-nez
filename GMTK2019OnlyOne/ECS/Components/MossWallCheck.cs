using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class MossWallCheck : Component, IUpdatable
    {
        public void update()
        {
            BoxCollider B = entity.getComponent<BoxCollider>();
            CollisionResult Result;

            B.collidesWithAny(out Result);

            if (Result.collider != null)
            {
                Sprite<Animation> A = entity.getComponent<Sprite<Animation>>();

                A.play(Animation.OnWall);
            }

            B.removeComponent();

            this.removeComponent();
        }
    }
}
