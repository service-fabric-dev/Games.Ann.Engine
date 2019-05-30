namespace Games.Ann.Models.Combatants
{
    public class GenericCombatant
    {
        public const int MaxHealth = 200;
        public const int Damage = 15;
        
        private int _currentHealth;

        public GenericCombatant()
        {
            _currentHealth = MaxHealth;
        }
    }
}
