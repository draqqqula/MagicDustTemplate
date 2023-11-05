using MagicDustLibrary.Logic;
using MagicDustLibrary.Network;
using MagicDustLibrary.Organization;
using MagicDustTemplate.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Linq;

namespace MagicDustTemplate
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MagicGameApplication _app;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameClient cleint = CreateClient();

            //Creating new application instance
            _app = new MagicGameApplication(cleint, this);

            //Loading level under certain name
            _app.LevelManager.LoadAs<TestLevel>("test");

            //Launching level under this name
            _app.LevelManager.Launch("test", true);

            //_app.LevelManager.LoadAs<ViewerLevel>("connection");
            //_app.LevelManager.Launch("connection", new LevelArgs($"{File.ReadLines("ServerIPAdress.txt").First()}:7878"), true);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            //Updating application
            _app.Update(gameTime.ElapsedGameTime, Window);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            //Drawing application
            _app.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private GameClient CreateClient()
        {
            //Creating new client instance
            //Since it will be our main client we don't have to feature remote IP adress
            return new GameClient(Window.ClientBounds, CreateControls(), GameClient.GameLanguage.English);
        }

        private GameControls CreateControls()
        {
            //Here we create controls for our client
            var controls = new GameControls();
            controls.ChangeControl(Control.left, () => Keyboard.GetState().IsKeyDown(Keys.A));
            controls.ChangeControl(Control.right, () => Keyboard.GetState().IsKeyDown(Keys.D));
            controls.ChangeControl(Control.jump, () => Keyboard.GetState().IsKeyDown(Keys.Space));
            controls.ChangeControl(Control.dash, () => Keyboard.GetState().IsKeyDown(Keys.LeftShift));
            controls.ChangeControl(Control.pause, () => Keyboard.GetState().IsKeyDown(Keys.Escape));
            controls.ChangeControl(Control.lookUp, () => Keyboard.GetState().IsKeyDown(Keys.W));
            controls.ChangeControl(Control.lookDown, () => Keyboard.GetState().IsKeyDown(Keys.S));
            return controls;
        }
    }
}