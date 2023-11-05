using MagicDustLibrary.CommonObjectTypes;
using MagicDustLibrary.Content;
using MagicDustLibrary.Display;
using MagicDustLibrary.Logic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicDustTemplate.ObjectTypes
{
    //Setting Hitbox size
    [Box(10)]
    //Setting SpriteSheet
    //Must be png image loaded in Content
    //Also you have to create <your .png name>_properties.txt containing info about animation
    //Make sure you indicated to copy latest version to output directory in .txt properties
    [SpriteSheet("Player")]
    public class TestType : Sprite
    {
        public GameClient Client;
        public TestType(IPlacement placement, Vector2 position, IAnimationProvider provider) : base(placement, position, provider)
        {
        }

        protected override DrawingParameters DisplayInfo
        {
            get
            {
                var info = base.DisplayInfo;
                info.Scale = new Vector2(1f, 1f);
                return info;
            }
        }

        public override void OnTick(IStateController state, TimeSpan deltaTime)
        {
            //code that will be running each update
            var speed = (float)deltaTime.TotalSeconds * 60f;

            if (Client.Controls[Control.right])
            {
                SetPosition(GetPosition() + new Vector2(speed, 0));
                IsMirroredHorizontal = false;
                if (Animator.Running.Name != "Running")
                {
                    Animator.SetAnimation("Running", 0);
                }
            }
            else if (Client.Controls[Control.left])
            {
                SetPosition(GetPosition() + new Vector2(-speed, 0));
                IsMirroredHorizontal = true;
                if (Animator.Running.Name != "Running")
                {
                    Animator.SetAnimation("Running", 0);
                }
            }
            else
            {
                Animator.SetAnimation("Default", 0);
            }
        }
    }
}
