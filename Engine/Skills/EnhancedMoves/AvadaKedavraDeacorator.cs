using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.EnhancedMoves
{
    [Serializable]
    public class AvadaKedavraDeacorator : SkillDecorator
    {
        public AvadaKedavraDeacorator(Skill skill) : base("Avada Kedavra", 50, 6, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 3;
            PublicName = "COMBO - Avada Kedavra: you have 10% chances to double damage [fire] AND " +
                         decoratedSkill.PublicName.Replace("Combo: ", "");
            RequiredItem = "Staff";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("fire");
            int range = Index.RNG(5, 95);
            int random = Index.RNG(0, 100);
            if (random >= (range - 5) && random <= (range + 5))
            {
                response.HealthDmg = 2 * player.Strength;
                response.CustomText = "You use doubled Avada Kedevra (" + 2 * player.Strength + " fire damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "Unable to use combo";
            }
            List <StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}