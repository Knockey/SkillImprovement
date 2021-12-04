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
            Value = healthValueDefault;
        }

        public int Value { get; private set; }

        public bool IsDead => Value <= 0;

        public void ApplyDamage(Weapon weapon)
        {
            if (IsDead)
                throw new ArgumentOutOfRangeException(nameof(IsDead), IsDead, "Can't shoot dead!");

            if (weapon.Damage < 0)
                throw new ArgumentOutOfRangeException(nameof(weapon.Damage), weapon.Damage, "Can't dealt damage below zero!");

            int newHealthValue = Value - weapon.Damage;

            Value = newHealthValue < 0 ? 0 : newHealthValue;
        }
    }
}
