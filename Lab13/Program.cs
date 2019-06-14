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
            "Secret"
        };
        readonly static Menu menu = new Menu(menuElements);
        static UnivercityWorkers people = new UnivercityWorkers();
        public static void Main(string[] args)
        {
            int input = menu.GetChoose();
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
                        int removingIndex = menu.GetInt("номер удаляемого элемента");
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
