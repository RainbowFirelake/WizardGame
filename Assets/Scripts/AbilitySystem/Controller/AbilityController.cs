using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using WizardGame.AbilitySystem.Model;
using WizardGame.AbilitySystem.View;
using WizardGame.Common.Timers;

namespace WizardGame.AbilitySystem.Controller
{
    public class AbilityController
    {
        private readonly AbilityModel _model;
        private readonly AbilityView _view;
        private readonly Queue<AbilityCommand> _abilityQueue = new();
        private readonly CountdownTimer _timer = new(0);

        private AbilityController(AbilityView view, AbilityModel model)
        {
            _view = view;
            _model = model;

            ConnectModel();
            ConnectView();
        }

        public void Update(float deltaTime)
        {
            _timer.Tick(deltaTime);
            _view.UpdateRadial(_timer.Progress);

            if (!_timer.IsRunning && _abilityQueue.TryDequeue(out var command))
            {
                command.Execute();
                _timer.Reset();
                _timer.Start();
            }
        }

        private void ConnectModel()
        {
            _model.abilities.AnyValueChanged += UpdateButtons;
        }

        private void ConnectView()
        {
            for (int i = 0; i < _view.buttons.Length; i++)
            {
                _view.buttons[i].RegisterListener(OnAbilityButtonsPressed);
            }

            _view.UpdateButtonsSprites(_model.abilities);
        }

        private void OnAbilityButtonsPressed(int index)
        {
            if (_timer.Progress < 0.25f || !_timer.IsRunning)
            {
                if (_model.abilities[index] != null)
                {
                    _abilityQueue.Enqueue(_model.abilities[index].CreateCommand());
                }
            }

            EventSystem.current.SetSelectedGameObject(null);
        }

        private void UpdateButtons(IList<Ability> updatedAbilities) =>
            _view.UpdateButtonsSprites(updatedAbilities);

        public class Builder
        {
            private readonly AbilityModel _model = new AbilityModel();

            public Builder WithAbilities(IEnumerable<AbilityData> abilities)
            {
                foreach (var data in abilities)
                {
                    _model.Add(new Ability(data));
                }

                return this;
            }

            public AbilityController Build(AbilityView view)
            {
                if (view == null)
                {
                    var errorMessage = $"{nameof(AbilityController)} build failed " +
                        $"because parameter {nameof(AbilityView)} is null!";
                    
                    throw new System.ArgumentNullException(nameof(AbilityView), errorMessage);
                }

                return new AbilityController(view, _model);
            }
        }
    }
}
