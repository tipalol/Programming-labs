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
        private List<Person> people = new List<Person>();
        readonly static Random random = new Random();
        public int Length
        {
            get
            {
                if (people == null) throw new NullReferenceException("Коллекция не инициализирована");
                return people.Count;
            }
        }
        public new void Add(Person person)
        {
            if (people == null) throw new NullReferenceException("Коллекция не инициализирована");
            people.Add(person);
        }
        public new void Remove(Person person)
        {
            if (people == null) throw new NullReferenceException("Коллекция не инициализирована");
            people.Remove(person);
        }
        public new void RemoveAt(int index)
        {
            if (people == null) throw new NullReferenceException("Коллекция не инициализирована");
            if (index >= people.Count || index < 0) throw new IndexErrorException("Такого элемента не существует");
            people.RemoveAt(index);
        }
        public new void Clear()
        {
            if (people == null) throw new NullReferenceException("Коллекция не инициализирована");
            people.Clear();
        }
        public void Sort(int mode = 1)
        {
            if (people == null) throw new NullReferenceException("Коллекция не инициализирована");
            Person[] temp = people.ToArray();
            switch (mode)
            {

                case 1:
                    Array.Sort(temp, new ByName());
                    break;
                case 2:
                    Array.Sort(temp, new ByGender());
                    break;
            }
            people = new List<Person>(temp);
        }
        public new IEnumerator GetEnumerator()
        {
            return people.GetEnumerator();
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
                        people.Add(Teacher.GenerateTeacher());
                        break;
                    case 0:
                        people.Add(Student.GenerateStudent());
                        break;
                }
        }
        public void Print()
        {
            foreach (Person person in people)
                Console.WriteLine(person);
        }

    }
}
