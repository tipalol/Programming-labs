//
//  Teacher.cs
//  Teacher
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
using System.Collections;

namespace Lab10
{
    /// <summary>
    /// Класс определяет учителя
    /// </summary>
    public class Teacher : Person, IWorker, IComparable, ICloneable
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
        /// Рассказывает о себе
        /// </summary>
        public override string TellAbout()
        {
            return base.TellAbout() + $@",
            и я работаю преподавателем на должности {Job},
            а мой факультет - {Faculty}";
        }
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab10.Teacher"/>
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <param name="gender">Пол объекта</param>
        public Teacher(string name, int gender, string job, string faculty) : base (name, gender)
        {
            Job = job;
            Faculty = faculty;
        }
        public int CompareTo(object obj)
        {
            Teacher temp = (Teacher)obj;
            if (String.Compare(this.Name, temp.Name) > 0) return 1;
            if (String.Compare(this.Name, temp.Name) < 0) return -1;
            return 0;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
