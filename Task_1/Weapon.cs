using System;

namespace Task_1
{
    public class Weapon
    {
        private readonly int _damage;
        private readonly int _bulletsInClipDefault;

        private int _bulletsInClip;

        public Weapon(int damage, int bulletsInClipDefault)
        {
            _damage = damage;
            _bulletsInClipDefault = bulletsInClipDefault;

            _bulletsInClip = bulletsInClipDefault;
        }

        public int TryGetFireDamage()
        {
            if (IsNotAbleToShoot())
                throw new ArgumentOutOfRangeException(nameof(_bulletsInClip), _bulletsInClip, "Not enough bullets!");

            _bulletsInClip--;
            
            return _damage;
        }

        public void Reload()
        {
            _bulletsInClip = _bulletsInClipDefault;
        }

        private bool IsNotAbleToShoot()
        {
            return _bulletsInClip-- <= 0;
        }
    }
}
