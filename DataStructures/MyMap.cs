namespace DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MyMap<K, V>
    {
        private const int BUCKETSIZE = 20;

        private List<K> Keys = new List<K>();
               
        // An array of lists- the lists holds multiple values with same index (chaining)
        private List<V>[] Bucket = new List<V>[BUCKETSIZE];

        public MyMap()
        {
            // initialise bucket
            for (int i = 0; i < BUCKETSIZE; i++)
            {
                Bucket[i] = new List<V>();
            }
        }

        public List<K> GetKeys()
        {
            return Keys;
        }

        public void Put(K key, V value)
        {
            if (key == null || value == null)
            {
                throw new ArgumentNullException("Key or Value is null");
            }

            if (Keys.Contains(key))
            {
                throw new ArgumentException("Duplicates not allowed");
            }

            Keys.Add(key);

            // get hashcode to fit bucket index
            var bucketIndex = GetHashCode(key);

            // add to bucket
            Bucket[bucketIndex].Add(value);
        }

        public V Get(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            var bucketIndex = GetHashCode(key);

            V value = Bucket[bucketIndex][0];

            return value;
        }

        public void Remove(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            var bucketIndex = GetHashCode(key);

            // assuming the value is in first position in the list
            Bucket[bucketIndex][0] = default(V);

            Keys.Remove(key);
        }

        private int GetHashCode(K key)
        {
            var hashCode = key.GetHashCode();

            // ensure is positive
            var hashValue = hashCode < 0 ? (hashCode * -1) : hashCode;

            // get hashcode to fit bucket index
            return (hashValue % BUCKETSIZE);
        }
    }
}
