namespace Task_1.Interfaces
{
    public interface IHealth
    {
        public int HealthValue { get; }
        public bool IsAlive { get; }
        public bool IsDead { get; }

        public void TryApplyDamage(int damage);
    }
}
