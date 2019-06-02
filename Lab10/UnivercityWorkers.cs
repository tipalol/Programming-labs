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
        public void Sort()
        {
            IWorker[] temp = Workers.ToArray();
            Array.Sort(temp, new SortByName());
            Workers = new List<IWorker>(temp);
        }
    }
    public class SortByName : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            if (x is Teacher)
            {
                Person t1 = (Person)x;
                Person t2 = (Person)y;
                return String.Compare(t1.Name, t2.Name);
            }
            else if (x is Cleaner)
            {
                Person c1 = (Person)x;
                Person c2 = (Person)y;
                return String.Compare(c1.Name, c2.Name);
            }
            else
            {
                throw new Exception("Сравниваемый тип не является ни учителем ни уборщиком");
            }
        }
    }
}
