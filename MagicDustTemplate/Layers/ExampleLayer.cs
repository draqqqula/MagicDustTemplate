using MagicDustLibrary.Display;
using MagicDustLibrary.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicDustTemplate.Layers
{
    [LayerPriority(129)]
    public class ExampleLayer : Layer
    {
        public override DrawingParameters Process(DrawingParameters arguments, GameCamera camera)
        {
            //each object on this layer will be rotated 1/2 PI radians
            arguments.Rotation = MathF.PI * 0.5f;
            return arguments;
        }
    }
}
