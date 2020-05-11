using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.EnhancedMoves
{
    [Serializable]
    public class AggressiveSwordDecorator : SkillDecorator
    {
        public AggressiveSwordDecorator(Skill skill) : base("Aggressive Sword", 30, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Aggressive Sword: 0.5*MP damage [air] AND " +
                         decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Sword";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
           StatPackage response = new StatPackage("air");
           response.HealthDmg = (int) (0.5 * player.MagicPower);
           response.CustomText = "You use Aggressive Sword! (" + (int) (0.5 * player.MagicPower) + " air damage)";
           List<StatPackage> combo = decoratedSkill.BattleMove(player);
           combo.Add(response);
           return combo;
        }
    }
}