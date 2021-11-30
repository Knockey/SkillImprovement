using System;
using Task_1.Interfaces;

namespace Task_1
{
    public class Player : IHealth
    {
        private readonly int _healthValueDefault;

        public Player(int healthValueDefault)
        {
            if (healthValueDefault <= 0)
                throw new ArgumentOutOfRangeException(nameof(healthValueDefault), healthValueDefault, "Default health can't be below 1!");

            _healthValueDefault = healthValueDefault;
            HealthValue = healthValueDefault;
        }

        public int HealthValue { get; private set; }

        public bool IsDead => HealthValue <= 0;

        public void TryApplyDamage(Weapon weapon)
        {
            if (IsDead)
                throw new ArgumentOutOfRangeException(nameof(IsDead), IsDead, "Can't shoot dead!");

            if (weapon.Damage < 0)
                throw new ArgumentOutOfRangeException(nameof(weapon.Damage), weapon.Damage, "Can't dealt damage below zero!");

            HealthValue = HealthValue - weapon.Damage < 0 ? 0 : HealthValue - weapon.Damage;
        }
    }
}
