using System.Collections.Generic;
using Game.Engine.Items.Weapon;

namespace Game.Engine.Items.ItemFactories
{
    public class WeaponFactory : ItemFactory
    {
        public Item CreateItem()
        {
            int random = Index.RNG(0, 10);
            if (random == 0)
            {
                return new MinthrilArmor();
            }
            else
            {
                List<Item> weapons = new List<Item>()
                {
                    new BasicAxe(),
                    new BasicSpear(),
                    new BasicStaff(),
                    new BasicSword(),
                    new Wand(),
                    new SuperSword()
                };
                return weapons[Index.RNG(0, weapons.Count)];

            }
        }

        public Item CreateNonMagicItem()
        {
            List<Item> weapons = new List<Item>()
            {
                new BasicAxe(),
                new BasicSpear(),
                new BasicSword(),
                new SuperSword()
            };
            return weapons[Index.RNG(0, weapons.Count)];
        }

        public Item CreateNonWeaponItem()
        {
            int random = Index.RNG(0, 10);
            if (random >= 8)
                return new MinthrilArmor();
            else
            {
                List<Item> weapons = new List<Item>()
                {
                    new Wand(),
                    new BasicStaff()
                };
                return weapons[Index.RNG(0, weapons.Count)];
            }
        }
    }
}