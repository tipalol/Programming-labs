using System;
using System.Collections.Generic;
using Lab10;
namespace Lab11
{
    public class WorkersDictionary
    {
        readonly Dictionary<string, IWorker> dictionary;
        public int Count()
        {
            return dictionary.Count;
        }
        public Dictionary<string, IWorker>.KeyCollection Keys()
        {
            return dictionary.Keys;
        }
        public Dictionary<string, IWorker>.ValueCollection Values()
        {
            return dictionary.Values;
        }
        public bool ContainsKey(string key)
        {
            return dictionary.ContainsKey(key);
        }
        public WorkersDictionary()
        {
            dictionary = new Dictionary<string, IWorker>();
        }
    }
}
