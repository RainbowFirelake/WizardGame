using WizardGame.Common.EventBus;

namespace WizardGame.Events
{
    public class PlayerEvent : IEvent
    {
        public int health;
        public int mana;
    }
}
