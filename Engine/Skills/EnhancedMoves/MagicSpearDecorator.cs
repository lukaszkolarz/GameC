using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.EnhancedMoves
{
    [Serializable]
    public class MagicSpearDecorator : SkillDecorator
    {
        public MagicSpearDecorator(Skill skill) : base("Magic Spear", 20, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "Combo - Magic Spear: increases precision of attack by 80% AND " +
                         decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Spear";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("air");
            response.HealthDmg = (int) (0.8 * 0.6 * player.Precision);
            response.CustomText = "Precision of attack increased with Magic Spear Combo! (" +
                                  (int) (0.8 * 0.6 * player.Precision) + " incised damage";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}