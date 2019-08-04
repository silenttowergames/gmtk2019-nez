using GMTK2019OnlyOne.ECS.Components;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne.ECS.Systems
{
    public enum Items
    {
        None,
        Key,
        Torch,
        TorchLit,
    }

    public static class ItemPickupSystem
    {
        public static Items Item;

        public static ItemPickupComponent EmptyItem = null;

        public static int
            Money = 2,
            Modifier = 0,
            TotalDonations = 0
        ;

        static List<ItemPickupComponent> Components = new List<ItemPickupComponent>();

        public static void Add(ItemPickupComponent C)
        {
            if (Components.Contains(C))
            {
                return;
            }

            Components.Add(C);
        }

        public static void Remove(ItemPickupComponent C)
        {
            Components.Remove(C);
        }

        public static void Update()
        {
            Entity Player = Core.scene.findEntity("player");

            if (Player == null)
            {
                return;
            }

            Entity E = Core.scene.findEntity("huditem");
            Sprite<Items> S = E.getComponent<Sprite<Items>>();

            RectangleF PlayerR = new RectangleF(Player.position, new Vector2(8));

            foreach(ItemPickupComponent C in Components)
            {
                if (C.Item == Items.None)
                {
                    continue;
                }

                RectangleF CR = new RectangleF(C.entity.position, new Vector2(8));

                if (!PlayerR.intersects(CR))
                {
                    C.Touching = false;

                    continue;
                }

                if (C.Touching)
                {
                    break;
                }

                C.Touching = true;

                Items _Item = Item == Items.TorchLit ? Items.Torch : Item;

                Item = C.Item;

                C.Item = _Item;

                Modifier = 0;

                S.play(Item);

                UpdateText();

                break;
            }

            if (Item == Items.Torch && Modifier > 0)
            {
                Item = Items.TorchLit;

                S.play(Item);
            }
            else if (Item == Items.TorchLit && Modifier <= 0)
            {
                Item = Items.Torch;

                S.play(Item);
            }
        }

        public static void FullUpdate()
        {
            Entity E = Core.scene.findEntity("huditem");
            Sprite<Items> S = E.getComponent<Sprite<Items>>();
            S.play(Item);

            UpdateText();
        }

        public static void ModifierChange()
        {
            if(Modifier <= 0)
            {
                return;
            }

            Modifier--;

            UpdateText();
        }

        public static void UpdateText()
        {
            Entity E = Core.scene.findEntity("huditem");
            Text T = E.getComponent<Text>();
            T.setText(ItemName());
        }

        public static string ItemName()
        {
            switch (Item)
            {
                case Items.Key:
                    {
                        return "Key";
                    }
                case Items.Torch:
                case Items.TorchLit:
                    {
                        return string.Format("Torch (x{0})", Modifier);
                    }
            }

            return "None";
        }
    }
}
