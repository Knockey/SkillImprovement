using System;
using System.Collections.Generic;
using Task_2.Interfaces;

namespace Task_2
{
    public class Storage
    {
        private readonly List<GoodCell> _goodsList;

        public Storage()
        {
            _goodsList = new List<GoodCell>();
        }

        public IReadOnlyList<IReadOnlyGoodCell> GoodsList => _goodsList;

        public void RestockGoods(Good good, int amount)
        {
            GoodCell newCell = TryFindCell(good, amount, out int cellIndex);

            if (cellIndex == -1)
            {
                _goodsList.Add(newCell);
                return;
            }

            _goodsList[cellIndex].Merge(newCell);
        }

        public void WriteOffGoods(Good good, int amount)
        {
            GoodCell cellToReduce = TryFindCell(good, amount, out int cellIndex);

            if (cellIndex == -1)
                throw new NullReferenceException($"{nameof(good)} not exist!");

            _goodsList[cellIndex].ReduceAmount(cellToReduce);

            if (_goodsList[cellIndex] == null)
                _goodsList.RemoveAt(cellIndex);
        }

        private GoodCell TryFindCell(Good good, int amount, out int cellIndex)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount can't be less than one!");

            if (good == null)
                throw new NullReferenceException($"{nameof(good)} can't be null!");

            cellIndex = _goodsList.FindIndex(cell => cell.Good == good);

            return new GoodCell(good, amount);
        }
    }
}
