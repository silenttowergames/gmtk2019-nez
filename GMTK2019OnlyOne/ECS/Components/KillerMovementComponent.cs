using Microsoft.Xna.Framework;
using Nez;
using Nez.AI.Pathfinding;
using Nez.Tiled;
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

        WeightedGridGraph graph;

        List<Point> Path = null;

        Vector2
            NextPoint = new Vector2(),
            StalkPoint = new Vector2()
        ;

        TiledTileLayer Layer = null;

        AIState State = AIState.Stalk;

        Vector2 HidePosition = new Vector2(-64);

        Entity Player;

        Vector2? ChosenPatrolStalkPoint = null;

        public override void onAddedToEntity()
        {
            entity.position = HidePosition;
        }

        protected override Vector2 GetDelta()
        {
            return base.GetDelta();
        }

        public override void update()
        {
            Player = Core.scene.findEntity("player");

            if (State == AIState.Hide)
            {
                entity.position = HidePosition;

                return;
            }

            if (entity.position == HidePosition)
            {
                bool SpawnSuccess = false;

                do
                {
                    SpawnSuccess = SpawnOnScreen();
                }
                while (!SpawnSuccess);

                Debug.log(entity.position);
            }

            base.update();
        }

        bool SpawnOnScreen()
        {
            BoxCollider B = entity.getComponent<BoxCollider>();
            int Which = Numbers.Random(0, 4);
            Vector2 StartPos = new Vector2(
                Player.position.X - (Player.position.X % Core.scene.sceneRenderTargetSize.X),
                Player.position.Y - (Player.position.Y % Core.scene.sceneRenderTargetSize.Y)
            );

            switch (Which)
            {
                case 0:
                case 2:
                    {
                        for(int X = 0; X < 14; X++)
                        {
                            entity.position = StartPos + new Vector2(X * 8, Which == 2 ? 8 * 8 : 8) + new Vector2(4);

                            CollisionResult Result;
                            B.collidesWithAny(out Result);

                            if (Result.collider == null)
                            {
                                return true;
                            }
                        }

                        break;
                    }
                case 1:
                case 3:
                    {
                        for (int Y = 1; Y < 9; Y++)
                        {
                            entity.position = StartPos + new Vector2(Which == 1 ? 16 * 8 : 0, Y * 8) + new Vector2(4);

                            CollisionResult Result;
                            B.collidesWithAny(out Result);

                            if (Result.collider == null)
                            {
                                return true;
                            }
                        }

                        break;
                    }
            }

            return false;
        }

        protected bool InitPath()
        {
            // If the path isn't currently set, then set it
            // The path will be set & unset many times over the course of a single chase
            if (Path == null)
            {
                // If the collisions layer hasn't been set yet, set it
                // We need that to find paths around
                if (Layer == null)
                {
                    // First, get the main map
                    Entity Map = Core.scene.findEntity("map");

                    // If the map doesn't exist, there's nothing to find paths around
                    // Just quit, this should never happen
                    if (Map == null)
                    {
                        return false;
                    }

                    // Get the map data
                    // We use Tiled in this game
                    TiledMapComponent MapData = Map.getComponent<TiledMapComponent>();

                    // If there is no map data, then there's no use
                    // Just quit, this should never happen
                    if (MapData == null)
                    {
                        return false;
                    }

                    // Set the collision layer
                    Layer = MapData.collisionLayer;

                    // If the collision layer is null, there's no use
                    // Just quit, this should never happen
                    if (Layer == null)
                    {
                        return false;
                    }
                }

                // If the graph hasn't been set, set it
                // The graph is the object that sets the path
                if (graph == null)
                {
                    graph = new WeightedGridGraph(Layer);

                    // If graph didn't properly set, there's no use
                    // Just quit, this should never happen
                    if (graph == null)
                    {
                        return false;
                    }
                }

                // Set the path
                SetPath();

                // If the path is somehow still null, it's no use
                // Just quit, this should never happen
                if (Path == null)
                {
                    return false;
                }

                // If the path is more-or-less empty, make it null, then quit
                // (The first node is usually useless)
                // This should never happen
                if (Path.Count <= 1)
                {
                    ChosenPatrolStalkPoint = null;

                    Player = null;

                    Path = null;

                    return false;
                }

                // Set the place on the map we want to go to
                // We make it a Vector2 as opposed to a Point. It's easier for us to use it that way
                // We also multiply it by the map's tilesize, as the Point it gives us is coordinates
                NextPoint = new Vector2((Path[1].X * 8) + 4, (Path[1].Y * 8) - 4);
            }

            return true;
        }

        protected void SetPath()
        {
            Path = graph.search(
                new Point((int)Math.Floor(entity.position.X / 8), (int)Math.Floor((entity.position.Y + 8) / 8)),
                new Point((int)Math.Floor(StalkPoint.X / 8), (int)Math.Floor((StalkPoint.Y + 8) / 8))
            );
        }
    }
}
