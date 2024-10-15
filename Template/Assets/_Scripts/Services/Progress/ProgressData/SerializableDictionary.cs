using System;
using System.Collections.Generic;

namespace _Scripts.Services.Progress.ProgressData
{
    [Serializable]
    class SerializableDictionary<TKey, TValue>
    {
        public List<TKey> keys;
        public List<TValue> values;

        public SerializableDictionary(Dictionary<TKey, TValue> dictionary)
        {
            keys = new List<TKey>(dictionary.Keys);
            values = new List<TValue>(dictionary.Values);
        }

        public Dictionary<TKey, TValue> ToDictionary()
        {
            var dict = new Dictionary<TKey, TValue>();
            for (int i = 0; i < keys.Count; i++)
            {
                dict[keys[i]] = values[i];
            }

            return dict;
        }
    }
}