using System;

namespace Task_1
{
    public class Weapon
    {
        private readonly int _defaultAmountOfBullets;
        private int _currentAmountOfBullets;

        public int Damage { get; init; }

        public Weapon(int damage, int defaultAmountOfBullets)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage), damage, "Damage can't be less, than 1!");

            if (defaultAmountOfBullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(defaultAmountOfBullets), defaultAmountOfBullets, "Default amount of bullets can't be less, than 1!");

            Damage = damage;
            _defaultAmountOfBullets = defaultAmountOfBullets;
            _currentAmountOfBullets = defaultAmountOfBullets;
        }

        public void TryShoot(Player player)
        {
            if (IsNotEnoughBulletsToShoot())
                throw new ArgumentOutOfRangeException(nameof(_currentAmountOfBullets), _currentAmountOfBullets, "Not enough bullets");

            --_currentAmountOfBullets;
            player.TryApplyDamage(this);
        }

        private bool IsNotEnoughBulletsToShoot()
        {
            return --_currentAmountOfBullets <= 0;
        }
    }
}
