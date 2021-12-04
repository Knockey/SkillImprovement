using System;
using Task_2.Interfaces;

namespace Task_2
{
    public class GoodCell : IReadOnlyGoodCell
    {
        public GoodCell(Good good, int amount)
        {
            if (IsAmountLessThanOne(amount))
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Count can't be less than 1!");

            Good = good ?? throw new NullReferenceException($"{nameof(good)} can't be null!");

            Amount = amount;
        }

        public Good Good { get; init; }

        public int Amount { get; private set; }

        public GoodCell Merge(GoodCell cell)
        {
            if (cell == null)
                throw new NullReferenceException(nameof(cell));

            return new GoodCell(Good, Amount += cell.Amount);
        }

        public GoodCell ReduceAmount(GoodCell cell)
        {
            if (cell == null)
                throw new NullReferenceException(nameof(cell));

            int newAmount = Amount - cell.Amount;

            if (newAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(Amount), newAmount, "Not enough goods to reduce amount!");

            if (newAmount == 0)
                return null;

            return new GoodCell(Good, newAmount);
        }

        private bool IsAmountLessThanOne(int count)
        {
            return count <= 0;
        }
    }
}
