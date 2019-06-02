//
//  Teacher.cs
//  Teacher
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab10
{
    /// <summary>
    /// Класс определяет учителя
    /// </summary>
    public class Teacher : Person, IWorker
    {
        /// <summary>
        /// Получает факультет
        /// </summary>
        /// <value>Факультет</value>
        public string Faculty { get; private set; }
        /// <summary>
        /// Получает должность
        /// </summary>
        /// <value>Должность</value>
        public string Job { get; set; }
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab10.Teacher"/>
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <param name="gender">Пол объекта</param>
        public Teacher(string name, int gender, string job, string faculty) : base (name, gender, job)
        {
            Faculty = faculty;
        }
    }
}
