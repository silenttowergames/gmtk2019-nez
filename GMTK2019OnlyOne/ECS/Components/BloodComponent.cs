using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    class BloodComponent : RenderableComponent
    {
        protected Vector2
            Range,
            Size
        ;

        public override float width => Range.X;

        public override float height => Range.Y;

        protected List<Rectangle> Spots = new List<Rectangle>();

        protected Vector2 Offset;

        protected int SpotsCount;

        public BloodComponent(Vector2 _Range, Vector2 _Size, Vector2 _Offset = new Vector2(), int _Spots = 5)
        {
            Range = _Range;
            Size = _Size;
            Offset = _Offset - new Vector2(8);
            SpotsCount = _Spots;

            localOffset = new Vector2();

            layerDepth = 0.9f;
        }

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();

            CreateSpots(entity.position + Offset + (Range / 2), SpotsCount);
        }

        public void CreateSpots(Vector2 Offset, int _Spots = 1)
        {
            if (_Spots == 0)
            {
                return;
            }

            for (int i = 0; i < _Spots; i++)
            {
                CreateSpot(Offset - (Range / 2));
            }
        }

        public void CreateSpot(int OffsetX, int OffsetY)
        {
            Rectangle R = new Rectangle(
                OffsetX,
                OffsetY,
                Numbers.Random(1, (int)Size.X),
                Numbers.Random(1, (int)Size.Y)
            );

            R.X += Numbers.Random(0, (int)Range.X - R.Width);
            R.Y += Numbers.Random(0, (int)Range.Y - R.Height);

            Spots.Add(R);
        }

        public void CreateSpot(Vector2 Offset)
        {
            CreateSpot((int)Offset.X, (int)Offset.Y);
        }

        public override void render(Graphics graphics, Camera camera)
        {
            foreach (Rectangle R in Spots)
            {
                graphics.batcher.drawRect(
                    R,
                    Color.DarkRed
                );
            }
        }
    }
}
