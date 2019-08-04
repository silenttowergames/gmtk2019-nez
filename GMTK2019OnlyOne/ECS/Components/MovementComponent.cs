using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class MovementComponent : Component, IUpdatable
    {
        public void update()
        {
            HealthComponent H = entity.getComponent<HealthComponent>();
            Sprite<Animation> S = entity.getComponent<Sprite<Animation>>();

            if (H.Limit <= 0)
            {
                S.play(Animation.Dead);

                Dead();

                return;
            }

            Vector2 Delta = GetDelta();

            if (Delta == Vector2.Zero)
            {
                return;
            }

            CollisionResult Result;
            entity.getComponent<Collider>().collidesWithAny(ref Delta, out Result);

            if (Result.collider != null)
            {
                TouchCollider(Result.collider);

                return;
            }

            if (S != null)
            {
                S.flipX = !S.flipX;
            }

            DidMove();

            entity.position += Delta;

            if (entity.position.Y % Core.scene.sceneRenderTargetSize.Y == 4)
            {
                entity.position += new Vector2(0, Delta.Y);
            }
        }

        protected virtual Vector2 GetDelta()
        {
            return new Vector2();
        }

        protected virtual void TouchCollider(Collider C)
        {
            //
        }

        protected virtual void DidMove()
        {
            //
        }

        protected virtual void Dead()
        {
            //
        }
    }
}
