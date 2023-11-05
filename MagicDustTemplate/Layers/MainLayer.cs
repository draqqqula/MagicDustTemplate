using MagicDustLibrary.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicDustTemplate.Layers
{
    //Global prority of layer
    //Used when drawing application
    [LayerPriority(128)]
    //Paralax parameters
    [Paralax(1, 1)]
    public class MainLayer : ParalaxLayer
    {
    }
}
