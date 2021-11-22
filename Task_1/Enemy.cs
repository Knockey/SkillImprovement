using System;

namespace Task_1
{
    public class Enemy
    {
        private readonly Weapon _weapon;

        public Enemy(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeeEnemy(Player player)
        {
            if (player == null)
                throw new NullReferenceException("Player is null!");

            if (player.IsAlive)
                TryShootPlayer(player);
        }

        private void TryShootPlayer(Player player)
        {
            if (IsWeaponNull())
                throw new NullReferenceException("Enemy weapon is null!");

            int damage;

            try
            {
                damage = _weapon.TryGetFireDamage();
            }
            catch (ArgumentOutOfRangeException exeption)
            {
                _weapon.Reload();
                damage = _weapon.TryGetFireDamage();
            }

            player.TryApplyDamage(damage);
        }

        private bool IsWeaponNull()
        {
            return _weapon == null;
        }
    }
}
