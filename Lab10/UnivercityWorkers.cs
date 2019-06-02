//
//  UnivercityWorkers.cs
//  UnivercityWorkers
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
using System.Collections;
using System.Collections.Generic;
namespace Lab10
{
    /// <summary>
    /// Класс определяет массив работников университета и методы работы с ним
    /// </summary>
    public class UnivercityWorkers : IEnumerable
    {
        /// <summary>
        /// Получает лист работников университета
        /// </summary>
        /// <value>Работники университета</value>
        public List<IWorker> Workers { get; private set; }
        public IEnumerator GetEnumerator()
        {
            return Workers.GetEnumerator();
        }
        public UnivercityWorkers(List<IWorker> workers)
        {
            Workers = workers;
        }
        public UnivercityWorkers()
        {
            Workers = new List<IWorker>();
        }
        public void Add(IWorker worker)
        {
            Workers.Add(worker);
        }
        public void RemoveAt(int index)
        {
            Workers.RemoveAt(index);
        }
        public IWorker this[int index]
        {
            get
            {
                return Workers[index];
            } 
            set
            {
                Workers[index] = value;
            }
        }
        public void Sort()
        {
            IWorker[] temp = Workers.ToArray();
            Array.Sort(temp, new SortByName());
            Workers = new List<IWorker>(temp);
        }
        public IWorker[] Find(string name)
        {
            IWorker[] workers = Workers.ToArray();
            workers = Array.FindAll(workers, i => (i as Person).Name == name);
            return workers;
        }
        public IWorker[] Find(int gender)
        {
            IWorker[] workers = Workers.ToArray();
            workers = Array.FindAll(workers, i => (i as Person).Gender == gender);
            return workers;
        }
        public IWorker[] Find(string job, int nothing)
        {
            IWorker[] workers = Workers.ToArray();
            workers = Array.FindAll(workers, i => i.Job == job);
            return workers;
        }
    }
    public class SortByName : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            if (x is Person && y is Person)
            {
                Person p1 = (Person)x;
                Person p2 = (Person)y;
                return String.Compare(p1.Name, p2.Name);
            }
            else
            {
                throw new Exception("Сравниваемый тип не является ни учителем ни уборщиком");
            }
        }
    }
}
