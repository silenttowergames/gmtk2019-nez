using GMTK2019OnlyOne.ECS.Systems;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class FireLightComponent : Component
    {
        public int FireLimit;

        public FireLightComponent(int _FireLimit = 10)
        {
            FireLimit = _FireLimit;
        }
    }
}
