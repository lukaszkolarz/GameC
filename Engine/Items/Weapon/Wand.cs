using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items.Weapon
{
    [Serializable]
    public class Wand: Staff
    {
        public Wand() : base("item0009")
        {
            PublicName = "Black wand";
            PublicTip = "Using increases HP by 10% and magic by 40%." +
                         "Also improves damage by 5% and magic attack by 20%" +
                         "If the attack was magic - damage -10 points";
            GoldValue = 70;
            HpMod = 10;         //in %    
            MgcMod = 40;        //in %
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.HealthBuff += (int)(currentPlayer.HealthBuff * HpMod / 100);
            currentPlayer.MagicPowerBuff += (int)(currentPlayer.MagicPower * MgcMod / 100);
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.MagicPowerDmg += (int)0.2 * pack.MagicPowerDmg;
            pack.HealthDmg += (int) 0.05 * pack.HealthDmg;
            return pack;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "earth" ||
                pack.DamageType == "air" ||
                pack.DamageType == "fire" ||
                pack.DamageType == "water")
            {
                pack.HealthDmg -= 10;
            }

            return pack;
        }
    }
}