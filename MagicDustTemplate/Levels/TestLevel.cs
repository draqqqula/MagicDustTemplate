using MagicDustLibrary.Logic;
using MagicDustLibrary.Organization;
using MagicDustTemplate.Layers;
using MagicDustTemplate.ObjectTypes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicDustTemplate.Levels
{
    public class TestLevel : GameLevel
    {
        protected override LevelSettings GetDefaults()
        {
            return new LevelSettings();
        }

        protected override void Initialize(IStateController state, LevelArgs arguments)
        {
            //code that will run at the start of the level

            //opening new server at certain port
            //now you can uncomment code on Game1.cs and connect to this same session
            //not necessary if you doing singleplayer game
            var port = 7878;
            state.OpenServer(port);
        }

        protected override void OnClientUpdate(IStateController state, GameClient client)
        {
            //code that will run on major client changes such as changing window size
        }

        protected override void OnConnect(IStateController state, GameClient client)
        {
            //code that will run each time new client connected to this level including main client
            //Creating object of TestType on layer ExampleLayer on position 300 x, 300 y
            var obj = state.CreateObject<TestType, MainLayer>(new Vector2(300, 300));
            obj.Client = client;
        }

        protected override void OnDisconnect(IStateController state, GameClient client)
        {
            //code that will run when client disconnected
        }

        protected override void Update(IStateController state, TimeSpan deltaTime)
        {
            //code that will run each Game.Update
        }
    }
}
