using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Windows.Forms;
using Game.Engine.Items.Weapon;
using Game.Engine.Skills.EnhancedMoves;

namespace Game.Engine.Interactions.WizardDiamonds
{
    [Serializable]
    public class WizardEncounter: ListBoxInteraction
    {
        public int Visited { private get; set; }
        private int capturedDiamonds;
        private EventManager eventManager;
        private AllDiamondsListener listener;

        public WizardEncounter(GameSession session, EventManager eventManager) : base(session)
        {
            capturedDiamonds = 0;
            Visited = 0;
            this.eventManager = eventManager;
            listener = new AllDiamondsListener(this);
            eventManager.Subscribe(listener, "newDiamond");
            Name = "interaction0005";
        }

        protected override void RunContent()
        {
            Visited += 1;

            if (Visited == -2)
            { 
                parentSession.SendText("\nThank you, now I can charm anytime. <3");
                return;
            }
            else if (Visited == -1)
            {
                parentSession.SendText("\nOh, you did it! I am very pleased. Here is your reward. " +
                                       "\nPlease, take my gifts.");
                parentSession.AddThisItem(new Wand());
                parentSession.LearnThisSkill(new MagicSpear());
                parentSession.UpdateStat(7, 50);             //gives 50 xp
                parentSession.UpdateStat(8, 200);            //gives 200 gold
                Visited = -2;
                return;

            } 
            else if (Visited >= 2)
            {
                parentSession.SendText("\nOh, what a pity. I am not able to charm anymore. *crying*");
                return;
            }

            parentSession.SendText("\nHello adventurer. I am the old wizard who lost all his diamonds. Now I " +
                                   "cannot charm. Would you like to help me?");

            int choice = GetListBoxChoice(new List<string>()
                {"Sure.", "What I'll get from you?", "I'm not interested right now."});
            switch (choice)
            {
                case 0:
                    Agree();
                    break;
                case 1:
                    Price();
                    break;
                case 2:
                    Exit();
                    break;
            }
        }

        public void Agree()
        {
            parentSession.SendText("Seriously, you will do it for me? <3 This map will help you go through caves to" +
                                   "find diamonds. Good luck!");
            eventManager.Notify("questStarted", "unlocked");
        }

        public void Price()
        {
            parentSession.SendText("I can offer you some magical experience and gold of course. Please, agree and do it!");
            int choice = GetListBoxChoice(new List<string>()
                {"Ok, I'll do it.", "I'm not interested right now."});
            switch (choice)
            {
                case 0:
                    Agree();
                    break;
                case 1:
                    Exit();
                    break;
            }
        }

        public void Exit()
        {
            Visited = 0;
        }
    }
}