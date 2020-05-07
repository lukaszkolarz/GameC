using System;
using System.Collections.Generic;

namespace Game.Engine.Monsters
{
    [Serializable]
    public class TheGroke : Monster
    {
        private String strategy;
        private int theGrokeLevel;

        public TheGroke(int theGrokeLevel)
        {
            Health = 150;
            Strength = 30;
            Armor = 0;
            Precision = 30;
            MagicPower = 50;
            Stamina = 100;
            XPValue = 50;
            Name = "monster0004";
            BattleGreetings = "BUUUUU";
            strategy = "casual";
            this.theGrokeLevel = theGrokeLevel;
        }

        public override List<StatPackage> BattleMove()
        {

            if (strategy.Equals("casual") && Stamina >= 10 && Strength >= 1)
            {
                Stamina -= 10;
                Strength -= 1;
                MagicPower -= 5;
                return new List<StatPackage>()
                {
                    new StatPackage("cut", 10 * theGrokeLevel,
                        "The Groke cuts and takes " + 10 * theGrokeLevel + " hp"),
                    new StatPackage("air", 0, 0, 10, 0, theGrokeLevel * 2,
                        "Attack with air. Taking 10 armor and " + theGrokeLevel * 2 + " magic"),
                };
            }
            else if (strategy.Equals("freeze") && MagicPower >= 10 && Stamina >= 8)
            {
                MagicPower -= 10;
                Stamina -= 8;
                return new List<StatPackage>()
                {
                    new StatPackage("water", 8 * theGrokeLevel, 0, 0, 5, 15 * theGrokeLevel,
                        "Freezing all around and takes " + 8 * theGrokeLevel + " hp and " + 15 * theGrokeLevel +
                        " magic")
                };
            }
            else if (strategy.Equals("spell") && MagicPower >= 20 && Stamina >= 10)
            {
                MagicPower -= 20;
                Stamina -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage("earth", 14 * theGrokeLevel, 0, 10, 5, 10 * theGrokeLevel,
                        "Freezing all around and takes " + 14 * theGrokeLevel + " hp, 10 armor, 5 precision and  "
                        + 15 * theGrokeLevel + " magic")
                };
            }
            else if (strategy.Equals("rest"))
            {
                Health += 2;
                Stamina -= 5;
                return new List<StatPackage>()
                {
                    new StatPackage("none", 0, "Recovering...")
                };
            }
            else
            {
                return new List<StatPackage>()
                {
                    new StatPackage("none", 0, "The Groke is moving back")
                };
            }
        }


        public override void React(List<StatPackage> packs)
        {
            List<String> strategyList = new List<string>();
            foreach (var pack in packs)
            {
                Health -= pack.HealthDmg;
                if (stamina < 20)
                    Strength -= 2 * pack.StrengthDmg;
                else
                    Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;

                if (pack.HealthDmg >= 35)
                    strategyList.Add("freeze");
                else if (Health == 20 && pack.HealthDmg <= 20)
                    strategyList.Add("rest");
                else if (pack.MagicPowerDmg <= 15)
                    strategyList.Add("spell");
                else
                    strategyList.Add("casual");
            }

            int rnd = Index.RNG(0, strategyList.Count);
            strategy = strategyList[rnd];
        }
    }
}