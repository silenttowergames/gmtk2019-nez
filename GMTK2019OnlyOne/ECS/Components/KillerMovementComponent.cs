using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class KillerMovementComponent : MovementComponent
    {
        enum AIState
        {
            Hide,
            Stalk
        }

        AIState State = AIState.Hide;

        public override void update()
        {
            if (State == AIState.Hide)
            {
                entity.position = new Vector2(-64);

                return;
            }

            if(entity.position == new Vector2(-64))
            {
                entity.position = new Vector2(32, 80);
            }

            base.update();
        }
    }
}
