//
//  WorkersQueue.cs
//  WorkersQueue
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
using System.Collections;
using System.Collections.Generic;
using Lab10;

namespace Lab11
{
    public class WorkersQueue : ICollection, IEnumerable, ICloneable
    {
        Queue workers;
        public int Count
        {
            get
            {
                return workers.Count;
            }
        }
        public bool IsSynchronized { 
            get
            {
                return workers.IsSynchronized;
            }
        }
        public object SyncRoot { get; }
        public IEnumerator GetEnumerator()
        {
            return workers.GetEnumerator();
        }
        public void CopyTo(Array array, int index)
        {
            if (array.GetValue(index) is Person)
                workers.CopyTo(array, index);
            else
                throw new Exception();
        }
        public object[] ToArray()
        {
            return workers.ToArray();
        }
        public object Clone()
        {
            return workers.Clone();
        }
        public bool Contains(object v)
        {
            return workers.Contains(v);
        }
        public void Clear()
        {
            workers.Clear();
        }
        public object Dequeue()
        {
            return workers.Dequeue();
        }
        public void Enqueue(object v)
        {
            workers.Enqueue(v);
        }
        public object Peek()
        {
            return workers.Peek();
        }
        public void TrimToSize()
        {
            workers.TrimToSize();
        }
        public WorkersQueue()
        {
            workers = new Queue();
        }
        public WorkersQueue(int capacity)
        {
            workers = new Queue(capacity);
        }
        public WorkersQueue(int capacity, float growFact)
        {
            workers = new Queue(capacity, growFact);
        }
        public WorkersQueue(ICollection collection)
        {
            workers = new Queue(collection);
        }
    }
}
