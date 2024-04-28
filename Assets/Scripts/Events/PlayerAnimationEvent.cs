using WizardGame.Common.EventBus;

public class PlayerAnimationEvent : IEvent
{
    public int AnimationHash { get; set; }
}
