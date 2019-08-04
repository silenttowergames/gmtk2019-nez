using GMTK2019OnlyOne.ECS.Systems;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Components
{
    public class MerchantComponent : Component
    {
        int Cost;

        Action OnBuy;

        bool Bought = false;

        public MerchantComponent(int _Cost, Action _OnBuy)
        {
            OnBuy = _OnBuy;
            Cost = _Cost;
        }

        public void TryBuy()
        {
            if (Bought || OnBuy == null || ItemPickupSystem.Money < Cost)
            {
                Game1.ScreenShake();

                return;
            }

            ItemPickupSystem.Money -= Cost;
            ItemPickupSystem.TotalDonations += Cost;

            Bought = true;

            OnBuy();
        }
    }
}
