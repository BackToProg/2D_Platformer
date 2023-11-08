using Base;

namespace Player
{
    public class Player : Person
    {
        public void Heal(int healValue) => IncreaseHealthValue(healValue);

        public int InitialHealth { get; private set; }

        private void Awake()
        {
            InitialHealth = Health;
        }

    }
}
