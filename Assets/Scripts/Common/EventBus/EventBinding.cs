using System;

namespace WizardGame.Common.EventBus
{
    public class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        private Action<T> onEvent = _ => { };
        private Action onEventNoArgs = () => { };

        Action<T> IEventBinding<T>.OnEvent 
        {
            get => onEvent; 
            set => onEvent = value; 
        }

        Action IEventBinding<T>.OnEventNoArgs 
        { 
            get => onEventNoArgs; 
            set => onEventNoArgs = value; 
        }

        public EventBinding(Action<T> onEvent) => this.onEvent = onEvent;
        public EventBinding(Action onEventNoArgs) => this.onEventNoArgs = onEventNoArgs;

        public void Add(Action onEvent) => onEventNoArgs += onEvent;
        public void Remove(Action onEvent) => onEventNoArgs -= onEvent;

        public void Add(Action<T> onEvent) => this.onEvent += onEvent;
        public void Remove(Action<T> onEvent) => this.onEvent -= onEvent; 
    }
}

