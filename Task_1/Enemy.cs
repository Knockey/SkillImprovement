using System;

namespace Task_1
{
    public class Enemy
    {
        private readonly Weapon _weapon;

        public Enemy(Weapon weapon)
        {
            _weapon = weapon ?? throw new NullReferenceException(nameof(weapon));
        }

        public void OnSeeEnemy(Player player)
        {
            if (player == null)
                throw new NullReferenceException(nameof(player));

            if (_weapon == null)
                throw new NullReferenceException(nameof(_weapon));

            if (player.IsDead == false)
                _weapon.TryShoot(player);
        }
    }
}
