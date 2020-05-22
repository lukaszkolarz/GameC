using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions.WizardDiamonds
{
    [Serializable]
    public class RedDiamondQuest : DiamondQuest
    {

        public RedDiamondQuest(GameSession session, EventManager eventManager) : base(session, eventManager)
        {
            Name = "interaction0006";
        }

        protected override void RunContent()
        {
            if (Locked)
            {
                parentSession.SendText("You haven't got any map to explore this place. Please find someone, who give " +
                                       "you one and come back later.");
                return;
            }
            
            parentSession.SendText("Hello, I'm a ghost, king of this cave. You can't see me but i can see you. " +
                                    "Somewhere there you will be able to find red diamond but Super Sword is required. ");
            if (parentSession.TestForItem("SuperSword"))
            {
                parentSession.SendText("\nYou have required SuperSword. Let's move on.");
            }
            else
            {
                parentSession.SendText("\nYou do not have required item or it is inactive. Please set it active or get " +
                                       "it somewhere and come back later.");
                return;
            }
            
            parentSession.SendText("\nCome on. There were few monsters appeared in the cave. FIGHT THEM!");
            parentSession.FightRandomMonster();
            parentSession.FightRandomMonster();
            
            parentSession.SendText("\nI have a question for you. What do you want to o when you will find red diamond?");
            int choice = GetListBoxChoice(new List<string>() {"I want to fight all people HAHAHAHAHA", 
                                                                      "I will give it back..."});
            switch (choice)
            {
                case 0:
                    parentSession.SendText("Get out far from there. You are not welcome there!");
                    break;
                case 1:
                    parentSession.SendText("Here is your diamond. Remember to give it back!");
                    eventManager.Notify("redDiamond", "newDiamond");
                    parentSession.SendText("You rewarded 100HP because of your brave and 50 gold for ice-creams");
                    parentSession.UpdateStat(7, 100);
                    parentSession.UpdateStat(8, 50);
                    break;
            }
        }
    }
}