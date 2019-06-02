//
//  Program.cs
//  Program
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;

namespace Lab10
{
    class MainClass
    {
        //Терминал, с помощью которого будет осуществляться взаимодействие с пользователем
        static UnivercityTerminal Terminal = UnivercityTerminal.GetInstance();
        //Список работников университета
        static UnivercityWorkers Workers = new UnivercityWorkers();
        public static void Main(string[] args)
        {
            int command = Terminal.ShowMenu();

            while (command != 0)
            {
                switch (command)
                {
                    case 1:
                        foreach (Person worker in Workers)
                            Terminal.Print(worker.TellAbout());
                        Console.ReadKey();
                        break;
                    case 2:
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
                                Workers.Add(newTeacher);
                                break;
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
                                Workers.Add(cleaner);
                                break;
                        }
                        Terminal.Print("Работник успешно добавлен");
                        break;
                    case 3:
                        string fireingWorkerName = Terminal.GetString("имя работника, которого нужно уволить");
                        
                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:
                        break;
                    case 8:

                        break;
                    case 9:
                        Terminal.Print("Список отсортирован по имени..");
                        Workers.Sort();
                        foreach (Person worker in Workers)
                            Terminal.Print( worker.TellAbout() );
                        Console.ReadKey();
                        break;
                    case 10:

                        break;
                    case 11:

                        break;
                }

                command = Terminal.ShowMenu();
                Terminal.Clear();
            }
        }
    }
}
