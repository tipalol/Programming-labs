//
//  Teacher.cs
//  Teacher
//
//  Created by Сорокин Дмитрий on 13/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
using System.Collections;

namespace Lab12
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
        public Teacher(string name, int gender, string job, string faculty) : base(name, gender)
        {
            Job = job;
            Faculty = faculty;
        }
        /// <summary>
        /// Сравнивает этот объект с указанным в параметре
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="obj">Объект</param>
        public int CompareTo(object obj)
        {
            Teacher temp = (Teacher)obj;
            if (String.Compare(this.Name, temp.Name) > 0) return 1;
            if (String.Compare(this.Name, temp.Name) < 0) return -1;
            return 0;
        }
        /// <summary>
        /// Клонирует этот объект
        /// </summary>
        /// <returns>The clone.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// Возвращает объект базового класса
        /// </summary>
        /// <value>The base person.</value>
        public Person BasePerson
        {
            get
            {
                return new Person(Name, Gender);
            }
        }
    }

}
