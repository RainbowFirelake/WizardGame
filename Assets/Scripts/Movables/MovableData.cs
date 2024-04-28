using UnityEngine;
using WizardGame.Common;

namespace WizardGame.Movables
{
    [CreateAssetMenu(menuName = MenuConstantsForSo.WizardGameRootFolderName + "/" + MenuConstantsForSo.MovablesFolderName + "/MovableData")]
    public class MovableData : ScriptableObject
    {
        [field: SerializeField]
        public float Speed = 5f;
    }
}