using System;

namespace Task_1
{
    public class Weapon
    {
        private readonly int _bulletsCount;
        private int _currentBulletsCount;

        public Weapon(int damage, int bulletsCount)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage), damage, "Damage can't be less, than 1!");

            if (bulletsCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(bulletsCount), bulletsCount, "Default amount of bullets can't be less, than 1!");

            Damage = damage;
            _bulletsCount = bulletsCount;
            _currentBulletsCount = bulletsCount;
        }

        public int Damage { get; init; }

        public void TryShoot(Player player)
        {
            --_currentBulletsCount;

            if (IsNotEnoughBulletsToShoot())
                throw new ArgumentOutOfRangeException(nameof(_currentBulletsCount), _currentBulletsCount, "Not enough bullets");

            player.ApplyDamage(this);
        }

        private bool IsNotEnoughBulletsToShoot() => _currentBulletsCount <= 0;
    }
}
