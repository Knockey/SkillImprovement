using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Interfaces;

namespace Task_2
{
    public class Warehouse
    {
        private readonly List<GoodCell> _goodsList;

        public Warehouse()
        {
            _goodsList = new List<GoodCell>();
        }

        public IReadOnlyList<IReadOnlyGoodCell> GoodsList => _goodsList;

        public void ReplenishGoods(Good good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "Count can't be less than one!");

            if (good == null)
                throw new NullReferenceException(nameof(good));

            var newCell = new GoodCell(good, count);
            GoodCell cell = _goodsList.FirstOrDefault(cell => cell.Good == good);

            if (newCell == null)
            {
                _goodsList.Add(newCell);
                return;
            }

            cell.Merge(newCell);
        }
    }
}
