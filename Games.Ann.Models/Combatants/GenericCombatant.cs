namespace Games.Ann.Models.Combatants
{
    public class GenericCombatant
    {
        public const int MaxHealth = 200;

        private int _currentHealth;

        public GenericCombatant()
        {
            _currentHealth = MaxHealth;
        }
    }
}
