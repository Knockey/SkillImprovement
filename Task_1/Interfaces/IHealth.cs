namespace Task_1.Interfaces
{
    public interface IHealth
    {
        public int HealthValue { get; }
        public bool IsDead { get; }

        public void TryApplyDamage(Weapon weapon);
    }
}
