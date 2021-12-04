namespace Task_1.Interfaces
{
    public interface IHealth
    {
        public int Value { get; }

        public bool IsDead { get; }

        public void ApplyDamage(Weapon weapon);
    }
}
