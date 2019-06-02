//
//  Person.cs
//  Person
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab10
{
    /// <summary>
    /// Класс определяет абстрактную персону
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Получает имя объекта
        /// </summary>
        /// <value>Имя объекта</value>
        public string Name { get; private set; }
        /// <summary>
        /// Получает пол человека
        /// </summary>
        /// <value>Пол человека</value>
        public int Gender { get; private set; }
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab10.Person"/>
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <param name="gender">Пол объекта</param>
        protected Person(string name, int gender)
        {
            Name = name;
            Gender = gender;
        }
    }
}
