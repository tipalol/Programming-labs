using System;

namespace Lab13
{
    class MainClass
    {
        readonly static string[] menuElements = {
            "Инициализировать коллекцию",
            "Вывести кол-во рабочих",
            "Добавить рабочего",
            "Удалить рабочего",
            "Выполнить сортировку",
            "Очистить коллекцию",
            "========Событийные коллекции=======",
            "Инициализировать две событийные коллекции",
            "Добавить элемент",
            "Удалить элемент",
            "Изменить элемент",
            "Показать журнал первой коллекции",
            "Показать журнал второй коллекции"
        };
        readonly static Menu menu = new Menu(menuElements);
        static UnivercityWorkers people = new UnivercityWorkers();
        static NewUnivercityWorkers eventCollection = new NewUnivercityWorkers("Первая коллекция");
        static NewUnivercityWorkers eventCollection2 = new NewUnivercityWorkers("Вторая коллекция");
        static Random random = new Random();
        static Journal firstJournal = new Journal();
        static Journal secondJournal = new Journal();
        static Person FormPerson()
        {
            switch (random.Next(1,3))
            {
                case 1:
                    return new Student($"Студент №{eventCollection.Count}", random.Next(1,3), random.Next(1,5));
                case 2:
                    return new Teacher($"Учитель №{eventCollection.Count}", random.Next(1,3), $"Факультет №{random.Next(1,5)}");
            }
            return null;
        }
        public static void Main(string[] args)
        {
            int input = menu.GetChoose();
            //Подключаем журналы к событиям
            eventCollection.CollectionCountChanged += firstJournal.CollectionCountChanged;
            eventCollection.CollectionReferenceChanged += firstJournal.CollectionReferenceChanged;
            eventCollection2.CollectionReferenceChanged += secondJournal.CollectionReferenceChanged;

            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        people = new UnivercityWorkers();
                        int count = menu.GetInt("Кол-во нужных элементов");
                        people.FillRandom(count);
                        people.Print();
                        Console.WriteLine("Коллекция успешно создана");
                        break;
                    case 2:
                        Console.WriteLine($"Кол-во элементов в коллекции: {people.Length}");
                        break;
                    case 3:
                        int typeOfAdding = menu.GetInt("кого хотите добавить (1 - студента, 2 - преподавателя)");
                        while (typeOfAdding > 2 || typeOfAdding < 1)
                        {
                            Console.WriteLine("К сожалению такого типа не существует.");
                            typeOfAdding = menu.GetInt("кого хотите добавить(1 - студента, 2 - преподавателя)");
                        }
                        switch (typeOfAdding)
                        {
                            case 1:
                                Student addingStudent = Student.GenerateStudent();
                                Console.WriteLine($"Добавляемый студент: {addingStudent}");
                                people.Add(addingStudent);
                                break;
                            case 2:
                                Teacher addingTeacher = Teacher.GenerateTeacher();
                                Console.WriteLine($"Добавляемый учитель: {addingTeacher}");
                                people.Add(addingTeacher);
                                break;
                        }
                        Console.ReadKey();
                        people.Print();
                        break;
                    case 4:
                        people.Print();
                        int removingIndex = menu.GetInt("номер удаляемого элемента")-1;
                        try
                        {
                            people.RemoveAt(removingIndex);
                        } catch (IndexErrorException e)
                        {
                            Console.WriteLine(e);
                        } catch (NullReferenceException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 5:
                        int sortMode = menu.GetInt("по какому полю сортировать (1 - по имени, 2 - по полу)");
                        while (sortMode > 2 || sortMode < 1)
                        {
                            Console.WriteLine("Такого способа не существует");
                            sortMode = menu.GetInt("по какому полю сортировать (1 - по имени, 2 - по полу)");
                        }
                        people.Sort(sortMode);
                        Console.WriteLine("Сортировка успешно завершена");
                        Console.ReadKey();
                        people.Print();
                        break;
                    case 6:
                        people.Clear();
                        Console.WriteLine("Коллекция успешно очищена");
                        break;
                    case 7:
                        Console.WriteLine("Да-да, тут есть события :)");
                        break;
                    case 8:
                        int size = menu.GetInt("размер коллекции");
                        eventCollection = new NewUnivercityWorkers("Первая");
                        eventCollection2 = new NewUnivercityWorkers("Вторая");
                        eventCollection.CollectionCountChanged += firstJournal.CollectionCountChanged;
                        eventCollection.CollectionReferenceChanged += firstJournal.CollectionReferenceChanged;
                        eventCollection2.CollectionReferenceChanged += secondJournal.CollectionReferenceChanged;
                        eventCollection.FillRandom(size);
                        eventCollection2.FillRandom(size);
                        eventCollection.Print();
                        Console.WriteLine("Две коллекции абсолютно одинаковы. Первая подписана на события изменения кол-ва элементов и изменения ссылок. Вторая подписана только на изменения ссылок.");
                        break;
                    case 9:
                        Person person = FormPerson();
                        eventCollection.Add(person);
                        eventCollection2.Add(person);
                        eventCollection.Print();
                        break;
                    case 10:
                        eventCollection.Print();
                        int removingIndexEvent = menu.GetInt("номер удаляемого элемента")-1;
                        eventCollection.Remove(removingIndexEvent);
                        eventCollection2.Remove(removingIndexEvent);
                        eventCollection.Print();
                        break;
                    case 11:
                        eventCollection.Print();
                        int changingIndex = menu.GetInt("номер изменяемого элемента")-1;
                        Person changingPerson = FormPerson();
                        eventCollection[changingIndex] = changingPerson;
                        eventCollection2[changingIndex] = changingPerson;
                        eventCollection.Print();
                        break;
                    case 12:
                        firstJournal.Print();
                        break;
                    case 13:
                        secondJournal.Print();
                        break;
                    default:
                        Console.WriteLine("Something goes wrong :(");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
                input = menu.GetChoose();
                Console.Clear();
            }
        }
    }
}
