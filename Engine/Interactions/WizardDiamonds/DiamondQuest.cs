namespace Game.Engine.Interactions.WizardDiamonds
{
    public abstract class DiamondQuest : ListBoxInteraction
    {
        private int visited;
        public bool Locked {protected get; set; }
        private DiamondQuestListener listener;
        protected EventManager eventManager;

        protected DiamondQuest(GameSession session, EventManager eventManager) : base(session)
        {
            visited = 0;
            Locked = true;
            this.eventManager = new EventManager();
            listener = new DiamondQuestListener(this);
            eventManager.Subscribe(listener, "unlocked");
        }
    }
}