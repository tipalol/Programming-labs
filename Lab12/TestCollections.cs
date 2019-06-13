using System;
using System.Collections.Generic;
namespace Lab12
{
    public class TestCollections
    {
        readonly List<Person> personList;
        readonly List<string> stringList;
        readonly Dictionary<string, Student> stringStudentDictionary;
        readonly Dictionary<Person, Student> personStudentDictionary;
        static int count = 0;
        public static Student GenerateStudent(int gender)
        {
            var random = new Random();
            count++;
            return new Student($"Студент №{count}", gender, random.Next(1,4));
        }
        public void AddStudent(Student student)
        {
            stringList.Add(student.Name);
            personList.Add(student.BasePerson);
            stringStudentDictionary.Add(student.Name, student);
            personStudentDictionary.Add(student.BasePerson, student);
        }
        public void RemoveStudent(string name)
        {
            try
            {
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
            }
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
