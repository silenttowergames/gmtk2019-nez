using GMTK2019OnlyOne.ECS.Components;
using GMTK2019OnlyOne.ECS.Systems;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Entities
{
    public static class EntityFactory
    {
        public static Entity Create(Vector2 Position, params Component[] Components)
        {
            Entity E = new Entity();

            foreach(Component C in Components)
            {
                E.addComponent(C);
            }

            E.position = Position + new Vector2(4);

            Core.scene.addEntity(E);

            return E;
        }

        public static Entity Blood(Vector2 Position)
        {
            return Create(Position, new BloodComponent(new Vector2(16), new Vector2(3)));
        }

        public static Entity Player(Vector2 Position)
        {
            Sprite<Animation> A = new Sprite<Animation>();
            A.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(3, 2)));
            A.addAnimation(Animation.Dead, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(3, 3)));
            A.play(Animation.Idle);
            A.layerDepth = 0.1f;

            Entity E = Create(Position, A, new BoxCollider(), new HealthComponent(), new PlayerMovementComponent(Position));

            E.name = "player";

            return E;
        }

        public static Entity Enemy()
        {
            Sprite<Animation> A = new Sprite<Animation>();
            A.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(3, 1)));
            A.play(Animation.Idle);

            Entity E = Create(new Vector2(), A, new BoxCollider(), new HealthComponent(), new KillerMovementComponent());

            E.name = "killer";

            return E;
        }

        public static Entity Merchant(Vector2 Position, int Cost, Action OnBuy = null)
        {
            Sprite<Animation> A = new Sprite<Animation>();
            A.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(7, 3)));
            A.play(Animation.Idle);

            Entity E = Create(Position, A, new BoxCollider(), new MerchantComponent(Cost, OnBuy));

            E.name = "merchant";

            return E;
        }

        public static Entity Door(Vector2 Position, Action<DoorComponent> OnEnter = null, bool Locked = false)
        {
            Sprite<Animation> A = new Sprite<Animation>();
            A.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(0, 3)));
            A.addAnimation(Animation.Locked, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(1, 3)));
            A.play(Locked ? Animation.Locked : Animation.Idle);
            A.layerDepth = 0.1f;

            Entity E = Create(Position, A, new BoxCollider(), new DoorComponent(OnEnter, Locked));

            return E;
        }

        public static Entity FireBowl(Vector2 Position)
        {
            Sprite<Animation> A = new Sprite<Animation>();
            A.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(4, 0), new Vector2(4, 1)));
            A.play(Animation.Idle);
            A.layerDepth = 0.1f;

            return Create(Position, A, new BoxCollider(), new FireLightComponent());
        }

        public static Entity Fire(Vector2 Position, int Lifetime = 3)
        {
            Sprite<Animation> A = new Sprite<Animation>();
            A.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(4, 3), new Vector2(4, 2)));
            A.play(Animation.Idle);

            Entity E = Create(Position, A, new BoxCollider(), new FireComponent(Lifetime));

            return E;
        }

        public static Entity TextWriter(Vector2 Position, string Text, string Name = "")
        {
            Text TextComp = new Text(Assets.NFonts["PressStart2P"], Text, new Vector2(-4), Color.White);
            TextComp.horizontalOrigin = HorizontalAlign.Center;

            Entity E = Create(Position + new Vector2(Core.scene.sceneRenderTargetSize.X / 2, 0), TextComp);

            if(Name != "")
            {
                E.name = Name;
            }

            return E;
        }

        public static Entity Moss(Vector2 Position, Action<BurningComponent> OnBurn = null)
        {
            Sprite<Animation> A = new Sprite<Animation>();
            A.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(3, 0)));
            A.addAnimation(Animation.OnWall, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(6, 2)));
            A.play(Animation.Idle);
            A.layerDepth = 0.5f;

            Entity E = Create(Position, A, new BurningComponent(OnBurn), new MossWallCheck(), new BoxCollider());

            return E;
        }

        public static Entity Wood(Vector2 Position, Action<BurningComponent> OnBurn = null)
        {
            Sprite<Animation> A = new Sprite<Animation>();
            A.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(2, 3)));
            A.play(Animation.Idle);
            A.layerDepth = 0.1f;

            Entity E = Create(Position, A, new BurningComponent(OnBurn, true), new BoxCollider());

            return E;
        }

        public static Entity Map(TiledMap Map)
        {
            TiledMapComponent M = new TiledMapComponent(Map, "collisions");

            M.layerDepth = 1;

            Entity E = Create(new Vector2(-4), M);

            E.name = "map";

            return E;
        }

        public static Entity IntroCard(string Title, Vector2 Position)
        {
            Position = new Vector2(
                Position.X - (Position.X % Core.scene.sceneRenderTargetSize.X),
                Position.Y - (Position.Y % Core.scene.sceneRenderTargetSize.Y)
            );

            Text T = new Text(Assets.NFonts["PressStart2P"], Title, Position + new Vector2((Core.scene.sceneRenderTargetSize.X - 8) / 2, 16), Color.White);
            T.horizontalOrigin = HorizontalAlign.Center;
            T.layerDepth = 0;

            BlackoutComponent B = new BlackoutComponent();
            B.layerDepth = 0.05f;

            Entity E = Create(new Vector2(), B, T);

            E.name = "intro-card";

            return E;
        }

        public static Entity HUDItem()
        {
            Vector2 Pos = new Vector2(4, 4);

            Sprite<Items> A = Animations.GetItemSprite(Items.None);
            A.layerDepth = 0.1f;

            Text T = new Text(Assets.NFonts["PressStart2P"], "None", new Vector2(8, -4), Color.White);
            T.layerDepth = 0.1f;

            Entity E = Create(Pos, A, T, new HUDPositionComponent(Pos));

            E.name = "huditem";

            return E;
        }

        public static Entity HUDHealth()
        {
            Vector2 Pos = new Vector2(Core.scene.sceneRenderTargetSize.X - 4, 4);

            Entity E = Create(Pos, new HUDCoinsComponent(), new HUDPositionComponent(Pos));

            E.name = "hudhealth";

            return E;
        }

        public static Entity Coin(Vector2 Position)
        {
            Sprite<Animation> S = new Sprite<Animation>();
            S.addAnimation(Animation.Idle, Animations.GetAnimation(Assets.Sprites["onlyone"], new Vector2(7, 0), new Vector2(7, 1)));
            S.play(Animation.Idle);
            S.layerDepth = 0.75f;

            Entity E = Create(Position, S, new MoneyComponent());

            return E;
        }

        public static Entity Item(Vector2 Position, Items _Item)
        {
            return Create(Position, Animations.GetItemSprite(_Item), new ItemPickupComponent(_Item));
        }
    }
}
