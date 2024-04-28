using UnityEngine;
using WizardGame.Common;

namespace WizardGame.AbilitySystem.Model
{
    [CreateAssetMenu(menuName = MenuConstantsForSo.WizardGameRootFolderName + "/" + MenuConstantsForSo.AbilitySystemFolderName + "/New Ability Data")]
    public class AbilityData : ScriptableObject
    {
        public AnimationClip animationClip;
        public int animationHash;
        public float duration;
        public Sprite icon;
        public string fullName;

        void OnValidate()
        {
            animationHash = Animator.StringToHash(animationClip.name);
        }
    }
}
