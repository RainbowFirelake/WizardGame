using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using WizardGame.AbilitySystem.Model;

namespace WizardGame.AbilitySystem.View
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField]
        public AbilityButton[] buttons;

        private readonly Key[] keys = { Key.Digit1, Key.Digit2, Key.Digit3, Key.Digit4, Key.Digit5 };

        private void Awake()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i >= keys.Length)
                {
                    Debug.LogError("Not enough keycodes for the number of buttons.");
                    break;
                }

                buttons[i].Initialize(i, keys[i]);
            }
        }

        public void UpdateRadial(float progress)
        {
            if (float.IsNaN(progress))
            {
                progress = 0;
            }
            Array.ForEach(buttons, button => button.UpdateRadialFill(progress));
        }

        public void UpdateButtonsSprites(IList<Ability> abilities)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i < abilities.Count)
                {
                    buttons[i].UpdateButtonSprite(abilities[i].data.icon);
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
