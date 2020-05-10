using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.EnhancedMoves
{
    [Serializable]
    public class AggressiveSword : Skill
    {
        public AggressiveSword() : base("Aggressive Sword", 30, 3)
        {
            PublicName = "Aggressive sword cut [requires Sword]: 0.6*Str + 0.4*Pr damage [cut]";
            RequiredItem = "Sword";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("cut");
            response.HealthDmg = (int)(0.6 * player.Strength) + (int)(0.4 * player.Precision);
            response.CustomText = "You use Aggressive Sword CUT! (" +
                                  ((int) (0.6 * player.Strength) + (int) (0.4 * player.Precision)) + " cut damage)";
            return new List<StatPackage>() { response };
        }
    }
}