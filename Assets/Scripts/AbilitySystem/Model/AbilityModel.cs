using WizardGame.Common.CustomCollections;

namespace WizardGame.AbilitySystem.Model
{
    public class AbilityModel
    {
        public readonly ObservableList<Ability> abilities = new();

        public void Add(Ability ability)
        {
            abilities.Add(ability);
        }
    }
}
