using WizardGame.AbilitySystem.Controller;
using WizardGame.AbilitySystem.Model;
using WizardGame.Common.EventBus;

public class AbilityCommand : ICommand
{
    public float Duration => data.duration;

    private readonly AbilityData data;

    public AbilityCommand(AbilityData data)
    {
        this.data = data;
    }

    public void Execute()
    {
        EventBus<PlayerAnimationEvent>.Raise(
            new PlayerAnimationEvent 
            { 
                AnimationHash = data.animationHash 
            });
    }
}
