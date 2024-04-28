using UnityEngine;
using WizardGame.Common.EventBus;
using WizardGame.Events;

public class Player : MonoBehaviour
{
    //TODO: для тестовых целей, убрать в будущем
    public int CurrentTestLevel = 1;

    private EventBinding<TestEvent> _testEventBinding;
    private EventBinding<PlayerEvent> _playerEventBinding;

    private void OnEnable()
    {
        _testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
        EventBus<TestEvent>.Register(_testEventBinding);
        _playerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
        EventBus<PlayerEvent>.Register(_playerEventBinding);
    }

    private void Update()
    {
        
    }

    private void HandleTestEvent()
    {
        Debug.Log("Test event received!");
    }

    private void HandlePlayerEvent(PlayerEvent playerEvent)
    {
        Debug.Log($"player event received! " +
            $"health = {playerEvent.health}, " +
            $"mana = {playerEvent.mana}");
    }
}
