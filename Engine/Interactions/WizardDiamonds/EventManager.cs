using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions.WizardDiamonds
{
    public class EventManager
    {
        private Dictionary<IObserver, String> listeners;

        public EventManager()
        {
            listeners = new Dictionary<IObserver, String>();
        }

        public void Subscribe(IObserver observer, String eventType)
        {
            listeners.Add(observer, eventType);
        }

        public void Unsubscribe(IObserver observer, String eventType)
        {
            listeners.Remove(observer);
        }

        public void Notify(String data, String eventType)
        {
            foreach (var listener in listeners)
            {
                if (eventType == listener.Value)
                    listener.Key.Update(data);
            }
        }
    }
}