using GMTK2019OnlyOne.ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public enum Animation
    {
        Idle,
        Dead,
        Locked,
        OnWall
    }

    public static class Animations
    {
        public static SpriteAnimation GetAnimation(Texture2D Texture, params Vector2[] Frames)
        {
            List<Subtexture> Subtextures = new List<Subtexture>();

            foreach(Vector2 Frame in Frames)
            {
                Subtextures.Add(GetSubtexture(Texture, Frame));
            }

            SpriteAnimation Anim = new SpriteAnimation(Subtextures);

            return Anim;
        }

        public static Subtexture GetSubtexture(Texture2D Texture, Vector2 Frame)
        {
            return new Subtexture(
                Texture,
                1 + (9 * Frame.X),
                1 + (9 * Frame.Y),
                8,
                8
            );
        }

        public static Sprite<Items> GetItemSprite(Items Use)
        {
            Sprite<Items> I = new Sprite<Items>();

            I.addAnimation(Items.None, GetAnimation(Assets.Sprites["onlyone"], new Vector2(6, 3)));
            I.addAnimation(Items.Key, GetAnimation(Assets.Sprites["onlyone"], new Vector2(5, 0)));
            I.addAnimation(Items.Torch, GetAnimation(Assets.Sprites["onlyone"], new Vector2(5, 1)));
            I.addAnimation(Items.TorchLit, GetAnimation(Assets.Sprites["onlyone"], new Vector2(5, 2), new Vector2(5, 3)));

            I.play(Use);

            I.layerDepth = 0.5f;

            return I;
        }
    }
}
