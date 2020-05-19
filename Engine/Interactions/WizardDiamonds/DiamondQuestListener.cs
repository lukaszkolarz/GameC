namespace Game.Engine.Interactions.WizardDiamonds
{
    public class DiamondQuestListener : IObserver
    {
        private DiamondQuest diamondQuest;
        public DiamondQuestListener(DiamondQuest diamondQuest)
        {
            this.diamondQuest = diamondQuest;
        }
        public void Update(string data)
        {
            diamondQuest.Locked = false;
        }
    }
}