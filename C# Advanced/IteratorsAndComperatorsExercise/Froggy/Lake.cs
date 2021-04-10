using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(params int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i += 2)
            {
                yield return stones[i];
            }

            if (stones.Length % 2 == 0)
            {
                for (int i = stones.Length - 1; i >= 0; i -= 2)
                {
                    yield return stones[i];
                }
            }
            else
            {
                for (int i = stones.Length - 2; i >= 0; i -= 2)
                {
                    yield return stones[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
