using System;
using Task_1.Interfaces;

namespace Task_1
{
    public class Player : IHealth
    {
        private readonly int _healthValueDefault;

        public int HealthValue { get; private set; }

        public bool IsDead => HealthValue <= 0;

        public bool IsAlive => HealthValue > 0;

        public Player(int healthValueDefault)
        {
            if (healthValueDefault <= 0)
                throw new ArgumentOutOfRangeException(nameof(healthValueDefault), healthValueDefault, "Default health can't be below 1!");

            _healthValueDefault = healthValueDefault;
            HealthValue = healthValueDefault;
        }

        public void TryApplyDamage(int damage)
        {
            if (IsDead)
                throw new ArgumentOutOfRangeException(nameof(IsDead), IsDead, "Can't shoot dead!");

            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage), damage, "Can't dealt damage below zero!");

            HealthValue = HealthValue - damage < 0 ? 0 : HealthValue - damage;
        }
    }
}
