using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.EnhancedMoves
{
    [Serializable]
    public class MagicSpear: Skill
    {
        public MagicSpear() : base("Magic Spear", 20, 3)
        {
            PublicName = "Magical spear cut [requires Spear]: 0.3*Str + 0.6*Pr [incised] and 0.2*MgPow [air]";
            RequiredItem = "Spear";
        }
        
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            response.HealthDmg = (int)(0.3 * player.Strength) + (int)(0.6 * player.Precision);
            response.CustomText = "You use Magical Spear incised! (" + ((int)(0.3 * player.Strength) + 
                                                                    (int)(0.6 * player.Precision)) + " incised damage)";
            StatPackage response2 = new StatPackage("air");
            response2.MagicPowerDmg = (int) (0.2 * player.MagicPower);
            response2.CustomText = "Magical spear puts a curse on opponent (" + (int) (0.2 * player.MagicPower) +
                                   " air damage)";
            return new List<StatPackage>()
            {
                response,
                response2
            };
        }
    }
}