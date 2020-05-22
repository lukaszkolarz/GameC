using System;
using System.Collections.Generic;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.WizardDiamonds
{
    [Serializable]
    public class BlueDiamondQuest : DiamondQuest
    {
        public BlueDiamondQuest(GameSession session, EventManager eventManager) : base(session, eventManager)
        {
            Name = "interaction0008";
        }

        protected override void RunContent()
        {
            if (Locked)
            {
                parentSession.SendText("You haven't got any map to explore this place. Please find someone, who give " +
                                       "you one and come back later.");
                return;
            }
            
            parentSession.SendText("Hello adventurer, wind told me you were looking for magical diamonds. " +
                                   "I have seen one in this cave but be careful. There are many monsters here. " +
                                   "They will not let you feel safely. Are you ready for coming inside?");

            int choice = GetListBoxChoice(new List<string>() {"Yes", "No, I will come back better prepared"});

            if (choice == 1)
            {
                return;
            }
            
            parentSession.FightThisMonster(new Rat(parentSession.currentPlayer.Level));
            parentSession.FightThisMonster(new RatEvolved(parentSession.currentPlayer.Level));
            parentSession.FightThisMonster(new Wizard(Index.RNG(3,8), parentSession.currentPlayer.Level));
            parentSession.FightThisMonster(new TheGroke(parentSession.currentPlayer.Level));
            
            parentSession.SendText("Congratulations. You killed all diamond guards. Here is blue diamond");
            eventManager.Notify("blueDiamond", "newDiamond");
            parentSession.SendText("Apart from that, you received 100 hp and random item");
            parentSession.UpdateStat(8, 100);
            parentSession.AddRandomItem();
        }
    }
}