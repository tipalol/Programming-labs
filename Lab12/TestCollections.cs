using System;
using System.Collections.Generic;
namespace Lab12
{
    public class TestCollections
    {
        public readonly List<Person> personList;
        public readonly List<string> stringList;
        public readonly Dictionary<string, Student> stringStudentDictionary;
        public readonly Dictionary<Person, Student> personStudentDictionary;
        /// <summary>
        /// Кол-во студентов в коллекциях
        /// </summary>
        public static int count = 0;
        /// <summary>
        /// Генерирует студента указанного пола
        /// </summary>
        /// <returns>The student.</returns>
        /// <param name="gender">Gender.</param>
        public static Student GenerateStudent(int gender)
        {
            var random = new Random();
            count++;
            return new Student($"Студент №{count}", gender, random.Next(1,4));
        }
        /// <summary>
        /// Добавляет студента в коллекцию
        /// </summary>
        /// <param name="student">Student.</param>
        public void AddStudent(Student student)
        {
            try
            {
                if (stringList == null) throw new NullReferenceException("Коллекции не были проинициализированы");
                stringList.Add(student.Name);
                personList.Add(student.BasePerson);
                stringStudentDictionary.Add(student.Name, student);
                personStudentDictionary.Add(student.BasePerson, student);
            } catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Удаляет студента из коллекции
        /// </summary>
        /// <param name="name">Name.</param>
        public void RemoveStudent(string name)
        {
            try
            {
                if (stringList == null) throw new NullReferenceException("Коллекции не были проинициализированы");
                if (stringList.Contains(name))
                {
                    stringList.Remove(name);
                    personList.Remove(personList.Find((Person obj) => obj.Name == name));
                    stringStudentDictionary.TryGetValue(name, out Student student);
                    stringStudentDictionary.Remove(name);
                    personStudentDictionary.Remove(student);
                }
                else throw new DidntExistElementException("Студент с таким именем отсутствует");
            } catch (DidntExistElementException e)
            {
                Console.WriteLine(e);
            } catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Выводит содержимое коллекции на экран
        /// </summary>
        public void Print()
        {
            foreach (Student student in stringStudentDictionary.Values)
                Console.WriteLine(student.TellAbout());
        }
        public TestCollections(int count = 0)
        {
            personList = new List<Person>(count);
            stringList = new List<string>(count);
            personStudentDictionary = new Dictionary<Person, Student>(count);
            stringStudentDictionary = new Dictionary<string, Student>(count);
        }
    }
}
