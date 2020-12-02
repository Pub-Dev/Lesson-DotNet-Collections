using System.Collections;
using System.Collections.Generic;

namespace PubDev.Collections
{
    public class PubDevEnumerable : IEnumerable<int>
    {
        private PubDevEnumerator _pubDevEnumerator;

        public PubDevEnumerable()
        {
            _pubDevEnumerator = new PubDevEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _pubDevEnumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}