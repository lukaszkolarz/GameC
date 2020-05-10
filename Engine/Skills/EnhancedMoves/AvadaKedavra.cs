using System;
using System.Collections.Generic;
using System.Windows.Markup;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.EnhancedMoves
{
    [Serializable]
    public class AvadaKedavra : Skill
    {
        public AvadaKedavra() : base("AvadaKedavra", 50, 6)
        {
            PublicName = "Avada Kedavra spell [requires stuff]: 1.0*Str [fire]";
            RequiredItem = "Staff";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("fire");
            response.HealthDmg = (player.Strength);
            response.CustomText = "AVADA KEDAVRA! You attack like Voldemort! (" +  player.Strength + " fire damage)";
            return new List<StatPackage>() { response };
        }
    }
}