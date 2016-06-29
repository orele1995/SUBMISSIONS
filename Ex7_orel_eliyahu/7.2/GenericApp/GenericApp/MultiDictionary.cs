using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class MultiDictionary<K, V> : IMultiDictionary<K,V>, IEnumerable<KeyValuePair<K, V>>
    {
        Dictionary<K, LinkedList<V>> multyDictionary = new Dictionary<K, LinkedList<V>>();
        int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                return multyDictionary.Keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                var list = new List<V>();
                foreach (KeyValuePair<K, LinkedList<V>> section in multyDictionary)
                {
                    foreach (V item in section.Value)
                    {
                        list.Add(item);

                    }
                }
                return list;
            }
        }

        public void Add(K key, V value)
        {
            if (multyDictionary.ContainsKey(key))
            {
                multyDictionary[key].AddLast(value);
            }
            else
            {
                multyDictionary.Add(key, new LinkedList<V>());
                multyDictionary[key].AddLast(value);
            }
            count++;
        }

        public void Clear()
        {
            multyDictionary.Clear();
            count = 0;
        }

        public bool Contains(K key, V value)
        {
            if (multyDictionary.ContainsKey(key))
            {
                if (multyDictionary[key].Find(value)!= null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool ContainsKey(K key)
        {
            if (multyDictionary.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        // removes only the first element
        public bool Remove(K key, V value)
        {
            if (multyDictionary.ContainsKey(key))
            {
                LinkedListNode<V> toRemove = multyDictionary[key].Find(value);
                if (toRemove == null)
                {
                    return false;
                }
                multyDictionary[key].Remove(toRemove);
                count--;
                return true;
            }
            return false;
        }

        public bool Remove(K key)
        {
            if (multyDictionary.ContainsKey(key))
            {
                count -= multyDictionary[key].Count;
                multyDictionary[key].Clear();
                multyDictionary.Remove(key);
                return true;
            }
            return false;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();
            foreach (KeyValuePair<K, LinkedList<V>> section in multyDictionary)
            {
                foreach (V item in section.Value)
                {
                    list.Add(new KeyValuePair<K, V>(section.Key, item));

                }
            }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }   
}


