//
//  Student.cs
//  Student
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab10
{
    /// <summary>
    /// Класс определяет студента
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// Получает курс студента
        /// </summary>
        /// <value>Курс студента</value>
        public int Course { get; private set; }
        /// <summary>
        /// Рассказывает о себе
        /// </summary>
        public override string TellAbout()
        {
            return base.TellAbout() + $", и я учусь на {Course} курсе";
        }
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab10.Student"/>
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <param name="gender">Пол объекта</param>
        public Student(string name, int gender, int course) : base (name, gender)
        {
            Course = course;
        }
    }
}
