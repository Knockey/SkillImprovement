using System;
using Task_2.Interfaces;

namespace Task_2
{
    public class GoodCell : IReadOnlyGoodCell
    {
        public Good Good { get; init; }
        public int Count { get; private set; }

        public GoodCell (Good good, int count)
        {
            if (IsCountLessThanOne(count))
                throw new ArgumentOutOfRangeException(nameof(count), count, "Count can't be less than 1!");

            Good = good ?? throw new NullReferenceException(nameof(good));
            Count = count;
        }

        public void Merge(GoodCell cell)
        {
            if (cell == null)
                throw new NullReferenceException(nameof(cell));

            Count += cell.Count;
        }

        private bool IsCountLessThanOne(int count)
        {
            return count <= 0;
        }
    }
}
