using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace Game.Engine.Monsters
{
    [Serializable]
    public class Wizard : Monster
    {
        private int wizardDegree;
        private int wizardLevel;
        private String strategy;

        public Wizard(int wizardDegree, int wizardLevel)
        {
            this.wizardDegree = wizardDegree;
            this.wizardLevel = wizardLevel;
            Health = 20 + 10 * wizardLevel;
            Strength = 10;
            Armor = 0;
            Precision = 50 + 10 * wizardDegree;
            MagicPower = 50 * wizardDegree;
            Stamina = 50;
            XPValue = 20 + wizardLevel + wizardDegree * 5;
            Name = "monster0003";
            BattleGreetings = "Let me charm u!";
            strategy = "normal";
        }

        public override List<StatPackage> BattleMove()
        {
            if (strategy.Equals("superPower") && stamina >= 30 && magicPower >= 30)
            {
                stamina -= 30;
                magicPower -= 30;
                return new List<StatPackage>()
                {
                    new StatPackage("fire", MagicPower / 4,
                        "Wizard uses super attack: Firstly fire takes " + MagicPower / 4 + " hp from u"),
                    new StatPackage("air", MagicPower / 4,
                        "Then, air blows and makes " + MagicPower / 4 + " damage"),
                    new StatPackage("water", MagicPower / 10,
                        "At the end, water flows and damages you " + MagicPower / 10 + " hp")
                };
            }
            else if (strategy.Equals("casual") && stamina >= 10 && strength >= 1 && magicPower >= 10)
            {
                stamina -= 10;
                strength -= 1;
                magicPower -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage("fire", 10 * wizardLevel,
                        "Wizard attack with fire taking " + 10 * wizardLevel + " hp"),
                    new StatPackage("air", 0, 10, 0, 0, wizardDegree,
                        "Attack with air. Taking 10 strength and " + wizardDegree + " magic"),
                    new StatPackage("earth", 0, 0, wizardLevel * 5, 0, 0,
                        "Ending attack with taking " + wizardLevel * 5 + " armory")
                };
            }
            else if (strategy.Equals("unarmed") && stamina >= 15 && strength >= 3)
            {
                stamina -= 15;
                strength -= 3;
                
                return new List<StatPackage>()
                {
                    new StatPackage("cut", 9, 2, 2, 2, 0,  
                        "Attack without magic")
                };
            }
            else if (strategy.Equals("weak"))
            {
                stamina -= 10;
                magicPower -= 10;
                return new List<StatPackage>()
                {
                    new StatPackage("water", 4*wizardDegree, 0, 0, 0, wizardLevel*4,
                        "Weak attack. " + 4*wizardDegree + " hp and " + wizardLevel*4 + " magic taken")
                };
            }
            else
            {
                return new List<StatPackage>() {new StatPackage("none", 0, 
                    "Wizard cannot attack")};
            }
        }

        public override void React(List<StatPackage> packs)
        {
            int rnd = Index.RNG(0, 5);
            base.React(packs);
            if (Health < 5 && Stamina >= 30 && wizardDegree >= 2 & rnd >= 2)
            {
                strategy = "superPower";
            }
            else if (MagicPower <= 2 && rnd >=2)
            {
                strategy = "unarmed";
            }
            else if (rnd < 2 && magicPower >= 10)
            {
                strategy = "weak";
            }
            else
            {
                strategy = "casual";
            } 
        }
    }
}