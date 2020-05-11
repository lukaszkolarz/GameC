using System;
using System.Collections.Generic;
using System.Windows.Markup;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.EnhancedMoves
{
    [Serializable]
    public class AxeAvadaKedavra : Skill
    {
        public AxeAvadaKedavra() : base("Axe Avada Kedavra", 50, 6)
        {
            PublicName = "Avada Kedavra spell [requires stuff]: 1.0*Str [fire]";
            RequiredItem = "Axe";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("fire");
            response.HealthDmg = (player.Strength);
            response.CustomText = "AVADA KEDAVRA! You try to kill with axe! (" +  player.Strength + " fire damage)";
            return new List<StatPackage>() { response };
        }
    }
}