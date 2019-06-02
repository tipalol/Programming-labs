//
//  Program.cs
//  Program
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
using System.Collections.Generic;

namespace Lab10
{
    class MainClass
    {
        //Терминал, с помощью которого будет осуществляться взаимодействие с пользователем
        static UnivercityTerminal Terminal = UnivercityTerminal.GetInstance();
        //Список работников университета
        static UnivercityWorkers Workers = new UnivercityWorkers();
        //Список студентов
        static List<Student> Students = new List<Student>();
        static IWorker CreateWorker()
        {
            int workerType = Terminal.GetInt("какого именно работника необходимо добавить? (1 - преподаватель, 2 - работник клининговой компании)");
            switch (workerType)
            {
                //Преподаватель
                case 1:
                    string newTeacherName = Terminal.GetString("имя нового преподавателя");
                    int newTeacherGender = Terminal.GetInt("пол нового преподавателя (1 - мужской, 2 - женский)");
                    if (newTeacherGender < 1 || newTeacherGender > 2)
                    {
                        Terminal.Print("Не удалось распознать пол. Выставлен мужской.");
                        newTeacherGender = 1;
                    }
                    string newteacherJob = Terminal.GetString("должность нового преподавателя");
                    string newTeacherFaculty = Terminal.GetString("факультет нового преподавателя");
                    Teacher newTeacher = new Teacher(newTeacherName, newTeacherGender, newteacherJob, newTeacherFaculty);
                    //Workers.Add(newTeacher);
                    return newTeacher;
                //Работник клининговой компании
                case 2:
                    string newCleanerName = Terminal.GetString("имя нового работника клининговой компании");
                    int newCleanerGender = Terminal.GetInt("пол нового работника клининговой компании (1 - мужской, 2 - женский)");
                    if (newCleanerGender < 1 || newCleanerGender > 2)
                    {
                        Terminal.Print("Не удалось распознать пол. Выставлен мужской.");
                        newCleanerGender = 1;
                    }
                    string newCleanerJob = Terminal.GetString("должность нового рабтника");
                    Cleaner cleaner = new Cleaner(newCleanerName, newCleanerGender, newCleanerJob);
                    //Workers.Add(cleaner);
                    return cleaner;
            }
            return null;
        }
        public static void Main()
        {
            int command = Terminal.ShowMenu();

            while (command != 0)
            {
                switch (command)
                {
                    case 1:
                        foreach (Person worker in Workers)
                            Terminal.Print(worker.TellAbout());
                        if (Workers.Workers.Count == 0)
                            Terminal.Print("В университете не работает ни одного работника :(");
                        Console.ReadKey();
                        break;
                    case 2:
                        Workers.Add( CreateWorker() );
                        Terminal.Print("Работник успешно добавлен");
                        break;
                    case 3:
                        for (int i = 0; i < Workers.Workers.Count; i++)
                            Terminal.Print($"{i+1}. {(Workers.Workers[i] as Person).TellAbout()}");
                        int firedWorker = Terminal.GetInt("номер увольняемого работника")-1;
                        try
                        {
                            Workers.RemoveAt(firedWorker);
                            Terminal.Print("Работник успешно уволен");
                        } catch (Exception exception)
                        {
                            Terminal.Print($"Произошла ошибка: {exception.Message}");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        for (int i = 0; i < Workers.Workers.Count; i++)
                            Terminal.Print($"{i+1}. {(Workers.Workers[i] as Person).TellAbout()}");
                        int changingWorker = Terminal.GetInt("номер изменяемого работника")-1;
                        try
                        {
                            Workers[changingWorker] = CreateWorker();
                            Terminal.Print("Работник успешно изменен");
                        } catch (Exception exception)
                        {
                            Terminal.Print($"Произошла ошибка: {exception.Message}");
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        if (Students.Count == 0)
                        {
                            Terminal.Print("Студентов в университете нет. Добавлены тестовые студенты");
                            var random = new Random();
                            for (int i = 0; i < 10; i++)
                            {
                                var student = new Student($"Студент {i}", random.Next(0, 1), random.Next(1, 4));
                                Students.Add(student);
                            }
                        }
                        foreach (var student in Students)
                            Terminal.Print( student.TellAbout() );
                        Console.ReadKey();
                        break;
                    case 6:
                        int course = Terminal.GetInt("нужный курс");
                        foreach (var student in Students)
                            if (student.Course == course)
                            {
                                Terminal.Print( student.TellAbout() );
                            }
                        Console.ReadKey();
                        break;
                    case 7:
                        string faculty = Terminal.GetString("нужный факультет");
                        foreach (Person person in Workers)
                        {
                            if (person is Teacher)
                                if ((person as Teacher).Faculty == faculty)
                                    Terminal.Print(person.TellAbout());
                        }
                        Console.ReadKey();
                        break;
                    case 8:
                        int gender = 1;
                        foreach (Person person in Workers)
                            if (person.Gender == gender)
                                Terminal.Print( person.TellAbout() );
                        foreach (var student in Students)
                            if (student.Gender == gender)
                                Terminal.Print( student.TellAbout() );
                        Console.ReadKey();
                        break;
                    case 9:
                        Terminal.Print("Список отсортирован по имени..");
                        Workers.Sort();
                        foreach (Person worker in Workers)
                            Terminal.Print( worker.TellAbout() );
                        Console.ReadKey();
                        break;
                    case 10:
                        int mode = Terminal.GetInt("как будем искать? (1 - по имени, 2 - по гендеру, 3 - по должности)");
                        switch (mode)
                        {
                            case 1:
                                IWorker[] workers = Workers.Find(Terminal.GetString("имя искомого сотрудника"));

                                foreach (Person worker in workers)
                                    Terminal.Print(worker.TellAbout());

                                Console.ReadKey();
                                break;
                            case 2:
                                IWorker[] workers2 = Workers.Find(Terminal.GetInt("гендер искомого сотрудника"));

                                foreach (Person worker in workers2)
                                    Terminal.Print(worker.TellAbout());

                                Console.ReadKey();
                                break;
                            case 3:
                                IWorker[] workers3 = Workers.Find(Terminal.GetString("должность искомого сотрудника"), 0);

                                foreach (Person worker in workers3)
                                    Terminal.Print(worker.TellAbout());

                                Console.ReadKey();
                                break;
                        }
                        break;
                    case 11:
                        for (int i = 0; i < Workers.Workers.Count; i++)
                            Terminal.Print($"{i+1}. {(Workers[i] as Person).TellAbout()}");
                        if (Workers.Workers.Count == 0)
                            Terminal.Print("В университете не работает ни одного работника :(");
                        else
                        {
                            int choose = Terminal.GetInt("номер работника, которого необходимо клонировать")-1;
                            IWorker worker = null;
                            try
                            {
                                if (Workers[choose] is Teacher)
                                    worker = (Workers[choose] as Teacher).Clone() as Teacher;
                                if (Workers[choose] is Cleaner)
                                    worker = (Workers[choose] as Cleaner).Clone() as Cleaner;
                            } catch (Exception exception)
                            {
                                Terminal.Print($"Произошла ошибка: {exception.Message}");
                            }
                            Workers.Add(worker);
                        }
                        Console.ReadKey();
                        break;
                }

                command = Terminal.ShowMenu();
                Terminal.Clear();
            }
        }
    }
}
