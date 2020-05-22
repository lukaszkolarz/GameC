using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions.WizardDiamonds
{
    [Serializable]
    public class GreenDiamondQuest : DiamondQuest
    {
        public GreenDiamondQuest(GameSession session, EventManager eventManager) : base(session, eventManager)
        {
            Name = "interaction0007";
        }

        protected override void RunContent()
        {
            if (Locked)
            {
                parentSession.SendText("You haven't got any map to explore this place. Please find someone, who give " +
                                       "you one and come back later.");
                return;
            }

            parentSession.SendText("Hello adventurer, my name is Beatrice and I'll guide you in this cave" +
                                   "To find green diamond you have to answer few questions. Are you ready?");
            int choice = GetListBoxChoice(new List<string>() {"YES, always.", "No, I'll back later."});
            if (choice == 1)
            {
                return;
            }
            
            parentSession.SendText("Ok. So the first question is: Who wants diamond back?");
            choice = GetListBoxChoice(new List<string>() {"Witch", "Wizard", "Gollum", "Dwarf", "Me"});
            if (choice == 0 || choice == 2 || choice == 3 || choice == 4)
            {
                parentSession.SendText("Sorry, your answer is incorrect!");
                parentSession.FightRandomMonster();
                return;
            }
            
            parentSession.SendText("Congratulations. Let's go to second question. What will appear when rat vanishes?");
            choice = GetListBoxChoice(new List<string>() {"The Groke", "Wizard", "Rat Evolved", "Rat"});
            if (choice == 0 || choice == 1 || choice == 3)
            {
                parentSession.SendText("Sorry, your answer is incorrect!");
                parentSession.FightRandomMonster();
                return;
            }
            
            parentSession.SendText("You are almost there. Now third question. Who is actual rector of AGH?");
            choice = GetListBoxChoice(new List<string>()
                {"Jacek Kołodziej", "Marek Frankowski", "Tadeusz Słomka", "Krzysztof Boryczko"});
            if (choice == 2)
            {
                parentSession.SendText("Congratulations. You've finished our QUIZ. This is your diamond");
                eventManager.Notify("greenDiamond", "newDiamond");
                parentSession.SendText("In addition your health is increased by 10 and you receive new item");
                parentSession.UpdateStat(1, 10);
                parentSession.AddRandomItem();
            }
        }
    }
}