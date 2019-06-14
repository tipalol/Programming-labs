using System;

namespace Lab12
{
    class MainClass
    {
        /// <summary>
        /// Массив элементов меню
        /// </summary>
        readonly static string[] menuElements = {
            "Создать тестовый класс коллекций",
            "Добавить элемент",
            "Удалить элемент",
            "Найти элемент в коллекциях и измерить время поиска"
         };
        /// <summary>
        /// Основное меню
        /// </summary>
        readonly static Menu menu = new Menu(menuElements);
        /// <summary>
        /// Класс с тестовыми коллекциями
        /// </summary>
        static TestCollections testCollections = new TestCollections();
        static Random random = new Random();


        public static void Main()
        {
            int input = menu.GetChoose();

            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        int size = menu.GetInt("размер создаваемых коллекций");
                        testCollections = new TestCollections(size);
                        for (int i = 0; i < size; i++)
                            testCollections.AddStudent(TestCollections.GenerateStudent(random.Next(1,3)));
                        break;
                    case 2:
                        int gender = menu.GetInt("пол добавляемого студента");
                        Student student = TestCollections.GenerateStudent(gender);
                        testCollections.AddStudent(student);
                        Console.WriteLine("Студент добавлен");
                        break;
                    case 3:
                        string name = menu.GetString("имя удаляемого студента");
                        testCollections.RemoveStudent(name);
                        Console.WriteLine("Студент удален");
                        break;
                    case 4:
                        Console.WriteLine("Нахождение первого, центрального, последнего и несуществующего элемента в коллекции List<Person>..");
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        testCollections.personList.Contains(testCollections.personList[0]);
                        testCollections.personList.Contains(testCollections.personList[testCollections.personList.Count/2]);
                        testCollections.personList.Contains(testCollections.personList[testCollections.personList.Count -2]);
                        testCollections.personList.Contains(new Person("Nothing", 228));
                        watch.Stop();
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine($"Затраченное время: {elapsedMs} миллисекунд");
                        Console.WriteLine("Нахождение первого, центрального, последнего и несуществующего элемента в коллекции List<string>..");
                        watch = System.Diagnostics.Stopwatch.StartNew();
                        testCollections.stringList.Contains(testCollections.stringList[0]);
                        testCollections.stringList.Contains(testCollections.stringList[TestCollections.count / 2]);
                        testCollections.stringList.Contains(testCollections.stringList[TestCollections.count - 2]);
                        testCollections.stringList.Contains("Nothing");
                        watch.Stop();
                        elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine($"Затраченное время: {elapsedMs} миллисекунд");
                        Console.WriteLine("Нахождение первого, центрального, последнего и несуществующего элемента в коллекции Dictionary<string, Student>..");
                        watch = System.Diagnostics.Stopwatch.StartNew();
                        testCollections.stringStudentDictionary.ContainsKey(testCollections.stringList[0]);
                        testCollections.stringStudentDictionary.ContainsKey(testCollections.stringList[TestCollections.count / 2]);
                        testCollections.stringStudentDictionary.ContainsKey(testCollections.stringList[TestCollections.count - 2]);
                        testCollections.stringStudentDictionary.ContainsKey("Nothing");
                        testCollections.stringStudentDictionary.ContainsValue(new Student("Something", 228, 10));
                        watch.Stop();
                        elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine($"Затраченное время: {elapsedMs} миллисекунд");
                        Console.WriteLine("Нахождение первого, центрального, последнего и несуществующего элемента в коллекции Dictionary<Person, Student>..");
                        watch = System.Diagnostics.Stopwatch.StartNew();
                        testCollections.personStudentDictionary.ContainsKey(testCollections.personList[0]);
                        testCollections.personStudentDictionary.ContainsKey(testCollections.personList[TestCollections.count / 2]);
                        testCollections.personStudentDictionary.ContainsKey(testCollections.personList[TestCollections.count - 2]);
                        testCollections.personStudentDictionary.ContainsKey(new Person("Nothing", 228));
                        testCollections.personStudentDictionary.ContainsValue(new Student("Something", 228, 10));
                        watch.Stop();
                        elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine($"Затраченное время: {elapsedMs} миллисекунд");
                        break;
                    default:
                        Console.WriteLine("Something goes wrong :(");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
                testCollections.Print();
                Console.ReadKey();
                Console.Clear();
                input = menu.GetChoose();
                Console.Clear();
            }
        }
    }
}
