using UnityEngine;

namespace WizardGame.AbilitySystem.Model
{
    public class Ability : MonoBehaviour
    {
        public readonly AbilityData data;

        public Ability(AbilityData data)
        {
            this.data = data;
        }

        public AbilityCommand CreateCommand()
        {
            return new AbilityCommand(data);
        }
    }
}
