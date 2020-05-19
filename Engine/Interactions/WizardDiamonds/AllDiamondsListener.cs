using Game.Engine.Interactions.WizardDiamonds;

namespace Game.Engine.Interactions
{
    public class AllDiamondsListener: IObserver
    {
        private bool redDiamond;
        private bool greenDiamond;
        private bool blueDiamond;
        private WizardEncounter parent;

        public AllDiamondsListener(WizardEncounter parent)
        {
            this.parent = parent;
            blueDiamond = false;
            redDiamond = false;
            greenDiamond = false;
        }
        public void Update(string data)
        {
            if (data.Equals("redDiamond"))
            {
                redDiamond = true;
            }
            else if (data.Equals("greenDiamond"))
            {
                greenDiamond = true;
            }
            else if (data.Equals("blueDiamond"))
            {
                blueDiamond = true;
            }

            if (blueDiamond && redDiamond && greenDiamond)
            {
                parent.Visited = -1;
            }

        }
    }
}