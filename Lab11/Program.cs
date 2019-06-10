//
//  Program.cs
//  Program
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
using System.Collections;
using Lab10;

namespace Lab11
{
    class MainClass
    {
        static string[] menuElements = {
            "Создать очередь из работников университета",
            "Добавить работника в очередь",
            "Удалить работника из очереди",
            "Получить кол-во работников определенного типа",
            "Вывести работников определенного типа",
            "Вывести всех работников мужского пола",
            "Выполнить клонирование очереди",
            "Найти элемент в очереди",
            "==============Словарь=============",
            "Создать словарь из работников университета",
            "Добавить работника в словарь",
            "Удалить работника из словаря",
            "Получить кол-во работников определенного типа",
            "Вывести кол-во работников определенного типа",
            "Вывести всех работников женского пола",
            "Выполнить клонирование словаря",
            "Выполнить поиск в словаре",
            "==============Лист==============="

         };
        static Menu menu = new Menu(menuElements);
        static WorkersQueue queue = new WorkersQueue();
        static WorkersDictionary dictionary = new WorkersDictionary();
        static void FillCollections(int count)
        {
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                switch (i % 2)
                {
                    case 0:
                        queue.Enqueue(new Cleaner($"Уборщик №{i}", (i % 2)+1, "Рядовой работник клининговой компании"));
                        break;
                    case 1:
                        queue.Enqueue(new Teacher($"Учитель №{i}", (i % 2)+1, "Преподаватель", "Экономики, менеджмента и бизнес информатики"));
                        break;
                }
            }
        }
        static IWorker CreateWorker()
        {
            int workerType = menu.GetInt("какого именно работника необходимо добавить? (1 - преподаватель, 2 - работник клининговой компании)");
            switch (workerType)
            {
                //Преподаватель
                case 1:
                    string newTeacherName = menu.GetString("имя нового преподавателя");
                    int newTeacherGender = menu.GetInt("пол нового преподавателя (1 - мужской, 2 - женский)");
                    if (newTeacherGender < 1 || newTeacherGender > 2)
                    {
                        Console.WriteLine("Не удалось распознать пол. Выставлен мужской.");
                        newTeacherGender = 1;
                    }
                    string newteacherJob = menu.GetString("должность нового преподавателя");
                    string newTeacherFaculty = menu.GetString("факультет нового преподавателя");
                    Teacher newTeacher = new Teacher(newTeacherName, newTeacherGender, newteacherJob, newTeacherFaculty);
                    //Workers.Add(newTeacher);
                    return newTeacher;
                //Работник клининговой компании
                case 2:
                    string newCleanerName = menu.GetString("имя нового работника клининговой компании");
                    int newCleanerGender = menu.GetInt("пол нового работника клининговой компании (1 - мужской, 2 - женский)");
                    if (newCleanerGender < 1 || newCleanerGender > 2)
                    {
                        Console.WriteLine("Не удалось распознать пол. Выставлен мужской.");
                        newCleanerGender = 1;
                    }
                    string newCleanerJob = menu.GetString("должность нового рабтника");
                    Cleaner cleaner = new Cleaner(newCleanerName, newCleanerGender, newCleanerJob);
                    //Workers.Add(cleaner);
                    return cleaner;
            }
            return null;
        }
        public static void Main(string[] args)
        {
            int input = menu.GetChoose();
            while (input != 0)
            {
                Console.Clear();
                switch (input)
                {
                    case 1:
                        queue = new WorkersQueue();
                        int count = menu.GetInt("кол-во элементов в коллекции");
                        FillCollections(count);
                        queue.Print();
                        break;
                    case 2:
                        queue.Enqueue(CreateWorker());
                        queue.Print();
                        break;
                    case 3:
                        queue.Dequeue();
                        queue.Print();
                        break;
                    case 4:
                        int choose_ = menu.GetInt("какого работника вам необходимо найти (0 - уборщик, 1 - учитель)");
                        int countOfType = 0;
                        switch (choose_)
                        {
                            case 0:
                                foreach (IWorker worker in queue)
                                    if (worker is Cleaner)
                                        countOfType++;
                                break;
                            case 1:
                                foreach (IWorker worker in queue)
                                    if (worker is Teacher)
                                        countOfType++;
                                break;
                        }
                        Console.WriteLine($"Кол-во работников определенного типа: {countOfType}");
                        break;
                    case 5:
                        int choose = menu.GetInt("какого работника вам необходимо найти (0 - уборщик, 1 - учитель)");
                        switch (choose)
                        {
                            case 0:
                                foreach (IWorker worker in queue)
                                    if (worker is Cleaner)
                                        Console.WriteLine(((Cleaner)worker).TellAbout());
                                break;
                            case 1:
                                foreach (IWorker worker in queue)
                                    if (worker is Teacher)
                                        Console.WriteLine(((Teacher)worker).TellAbout());
                                break;
                            default:
                                Console.WriteLine("Таких работников в университете н работает");
                                break;
                        }
                        break;
                    case 6:
                        foreach (Person person in queue)
                            if (person.Gender == 1)
                                Console.WriteLine(person.TellAbout());
                        break;
                    case 7:
                        WorkersQueue clonnedQueue = (WorkersQueue) queue.Clone();
                        Console.WriteLine("Очередь успешно клонирована. Вывод на экран:");
                        clonnedQueue.Print();
                        break;
                    case 8:
                        string name = menu.GetString("искомое имя");
                        foreach (Person person in queue)
                            if (person.Name.Contains(name))
                                Console.WriteLine(person.TellAbout());
                        break;
                    case 9:
                        Console.WriteLine("Да, это словарь");
                        break;
                    case 10:

                        break;
                }
                Console.ReadKey();
                Console.Clear();
                input = menu.GetChoose();
            }
        }
    }
}
