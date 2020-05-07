using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items.Weapon
{
    [Serializable]
    public class MinthrilArmor: Item
    {
        public MinthrilArmor() : base("item0011")
        {
            PublicName = "Minthril Armor";
            PublicTip =
                "Minthril is the sturdiest material on Earth, very expensive but can resist all types of attacks."+
                "If u are a friend of dwarf (u have basic axe), it also increase your health by 20%.";
            GoldValue = 700;
            ArMod = 500;       // in points
            HpMod = 20;        // in %
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            foreach (var item in otherItems)
            {
                if (item.Equals("item003"))
                    currentPlayer.HealthBuff += (int)(currentPlayer.HealthBuff * HpMod / 100);
            }

            currentPlayer.ArmorBuff += 500;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "cut" ||
                pack.DamageType == "incised")
            {
                pack.HealthDmg -= (int)(60 * pack.HealthDmg / 100);
            }
            else
                pack.HealthDmg -= (int)(10 * pack.HealthDmg / 100);

            pack.MagicPowerDmg -= (int)(10 * pack.MagicPowerDmg / 100);
            return pack;
        }
    }
}