using System;
using System.Collections.Generic;
using Game.Engine.Interactions.WizardDiamonds;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    public class WizardDiamondsFactory : InteractionFactory
    {
        private EventManager eventManager;

        public WizardDiamondsFactory()
        {
            eventManager = new EventManager();
        }
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            
            WizardEncounter wizard = new WizardEncounter(parentSession, eventManager);
            RedDiamondQuest redDiamond = new RedDiamondQuest(parentSession, eventManager);
            GreenDiamondQuest greenDiamond = new GreenDiamondQuest(parentSession, eventManager);
            BlueDiamondQuest blueDiamond = new BlueDiamondQuest(parentSession, eventManager);
            
            return new List<Interaction>() {wizard, redDiamond, greenDiamond, blueDiamond};
        }
    }
}