using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class WizardFactory: MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create(int playerLevel)
        {
            int wizardDegree = Index.RNG(1, 4);
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Wizard(wizardDegree, playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint() 
        {
            if (encounterNumber == 0) return new Wizard(0, 0).GetImage();
            else return null; 
        }
    }
}