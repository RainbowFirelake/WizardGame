using UnityEngine;
using WizardGame.AbilitySystem.Controller;
using WizardGame.AbilitySystem.Model;
using WizardGame.AbilitySystem.View;

namespace WizardGame.AbilitySystem
{
    public class AbilitySystem : MonoBehaviour
    {
        [SerializeField]
        private AbilityView _view;

        [SerializeField]
        private AbilityData[] _startingAbilities;

        AbilityController _controller;

        private void Awake()
        {
            _controller = new AbilityController.Builder()
                .WithAbilities(_startingAbilities)
                .Build(_view);
        }

        private void Update()
        {
            _controller.Update(Time.deltaTime);
        }
    }
}
