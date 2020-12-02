using System.Collections;
using System.Collections.Generic;

namespace PubDev.Collections
{
    public class PubDevEnumerator : IEnumerator<int>
    {
        private int _index = -1;
        private int[] _data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public bool MoveNext()
        {
            _index++;
            if (_data.Length > _index)
            {
                var item = _data.GetValue(_index);
                if (item != null)
                {
                    Current = (int)item;
                    return true;
                }

                return false;
            }

            return false;
        }

        public void Reset()
        {
            _index = -1;
            Current = 0;
        }

        public int Current { get; private set; }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            //
        }
    }
}