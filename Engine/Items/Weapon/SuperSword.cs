using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items.Weapon
{
    [Serializable]
    public class SuperSword: Sword
    {
        private int lastReceivedDamage;
        public SuperSword() : base("item0010")
        {
            lastReceivedDamage = 0;
            PublicName = "Diamond Sword";
            PublicTip = "This sword increases damage HP by 40% of last received damage" +
                        "Also it improves owner's HP by 10 points but subtracts 10 points Stamina.";
            GoldValue = 120;
            HpMod = 10;            //in points
            StaMod = -10;          //in points
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.HealthBuff += HpMod;
            currentPlayer.StaminaBuff += StaMod;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.HealthDmg += (int)(0.4 * lastReceivedDamage);
            return pack;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            lastReceivedDamage = pack.HealthDmg;
            return pack;
        }
    }
}