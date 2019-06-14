using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System;

namespace Lab13
{
    /// <summary>
    /// Класс реализует коллекцию работников университета
    /// </summary>
    public class UnivercityWorkers : Collection<Person>
    {
        public List<Person> People { get; protected set; } = new List<Person>();
        readonly static Random random = new Random();
        public int Length
        {
            get
            {
                if (People == null) throw new NullReferenceException("Коллекция не инициализирована");
                return People.Count;
            }
        }
        public new void Add(Person person)
        {
            if (People == null) throw new NullReferenceException("Коллекция не инициализирована");
            People.Add(person);
        }
        public new void Remove(Person person)
        {
            if (People == null) throw new NullReferenceException("Коллекция не инициализирована");
            People.Remove(person);
        }
        public new void RemoveAt(int index)
        {
            if (People == null) throw new NullReferenceException("Коллекция не инициализирована");
            if (index >= People.Count || index < 0) throw new IndexErrorException("Такого элемента не существует");
            People.RemoveAt(index);
        }
        public new void Clear()
        {
            if (People == null) throw new NullReferenceException("Коллекция не инициализирована");
            People.Clear();
        }
        public void Sort(int mode = 1)
        {
            if (People == null) throw new NullReferenceException("Коллекция не инициализирована");
            Person[] temp = People.ToArray();
            switch (mode)
            {

                case 1:
                    Array.Sort(temp, new ByName());
                    break;
                case 2:
                    Array.Sort(temp, new ByGender());
                    break;
            }
            People = new List<Person>(temp);
        }
        public new IEnumerator GetEnumerator()
        {
            return People.GetEnumerator();
        }
        public class ByName : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                string xName = ((Person)x).Name;
                string yName = ((Person)y).Name;
                return new CaseInsensitiveComparer().Compare(xName, yName);
            }
        }
        public class ByGender : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                int xGender = ((Person)x).Gender;
                int yGender = ((Person)y).Gender;
                if (xGender == yGender) return 0;
                else if (xGender > yGender) return 1;
                else return -1;
            }
        }
        
        /// <summary>
        /// Заполняет коллекцию случайными элементами
        /// </summary>
        /// <param name="count">Кол-во нужных элементов</param>
        public void FillRandom(int count)
        {
            for (int i = 0; i < count; i++)
                switch (random.Next(0,2))
                {
                    case 1:
                        People.Add(Teacher.GenerateTeacher());
                        break;
                    case 0:
                        People.Add(Student.GenerateStudent());
                        break;
                }
        }
        public void Print()
        {
            foreach (Person person in People)
                Console.WriteLine(person);
        }

    }
}
