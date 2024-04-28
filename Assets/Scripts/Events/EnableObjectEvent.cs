using WizardGame.Common.EventBus;

namespace WizardGame.Events
{
    public class EnableObjectEvent : IEvent
    {
        public int Id { get; set; }
        public int Level { get; set; }
    }
}
