using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Interfaces;

namespace Task_1
{
    public class Player : IHealth
    {
        private readonly int _healthValueDefault;

        private int _healthValue;

        public int HealthValue => _healthValue;

        public bool IsDead => _healthValue <= 0;

        public bool IsAlive => _healthValue > 0;

        public Player(int healthValueDefault)
        {
            _healthValueDefault = healthValueDefault;
            _healthValue = healthValueDefault;
        }

        public void TryApplyDamage(int damage)
        {
            if (IsDead)
                throw new ArgumentOutOfRangeException(IsDead.ToString(), IsDead, "Can't shoot dead!");

            if (damage < 0)
                throw new ArgumentOutOfRangeException(damage.ToString(), damage, "Can't dealt damage below zero!");

            _healthValue = _healthValue - damage < 0 ? 0 : _healthValue - damage;
        }
    }
}
