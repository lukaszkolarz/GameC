using System;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class TheGrokeFactory: MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new TheGroke(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint() 
        {
            if (encounterNumber == 0) return new TheGroke(0).GetImage();
            return null; 
        }
    }
}