using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace WizardGame.AbilitySystem.View
{
    [RequireComponent(typeof(Button))]
    public class AbilityButton : MonoBehaviour
    {
        public Image radialImage;
        public Image abilityIcon;
        public int index;
        public Key key;

        public event Action<int> OnButtonPressed = delegate { };

        private void OnValidate()
        {
            if (radialImage != null && radialImage.type != Image.Type.Filled)
            {
                Debug.LogWarning($"Radial image on {gameObject.name} must have type 'Filled'!");
            }
        }

        public void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => OnButtonPressed(index));
        }

        public void Update()
        {
            if (Keyboard.current[key].wasPressedThisFrame)
            {
                OnButtonPressed(index);
            }
        }

        public void RegisterListener(Action<int> listener)
        {
            OnButtonPressed += listener;
        }

        public void Initialize(int index, Key key)
        {
            this.key = key;
            this.index = index;
        }

        public void UpdateButtonSprite(Sprite newIcon)
        {
            abilityIcon.sprite = newIcon;
        }

        public void UpdateRadialFill(float progress)
        {
            if (radialImage != null) 
            {
                radialImage.fillAmount = progress;
            }
        }
    }
}
