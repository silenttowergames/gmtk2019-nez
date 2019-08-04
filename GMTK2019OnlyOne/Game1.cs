using GMTK2019OnlyOne.ECS.Components;
using GMTK2019OnlyOne.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace GMTK2019OnlyOne
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {
        public static Color BGColor = new Color(44, 33, 55);

        public static void ScreenShake()
        {
            Core.scene.camera.addComponent(new CameraShakeComponent());
        }

        public Game1()
        {
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            Assets.Load();

            Screen.setSize(128 * 8, 72 * 8);

            Scene.setDefaultDesignResolution(128, 72, Scene.SceneResolutionPolicy.ExactFit);

            scene = new Level2Scene();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Input.isKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }
    }
}
