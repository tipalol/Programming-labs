﻿//
//  Person.cs
//  Person
//
//  Created by Сорокин Дмитрий on 13/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab12
{
    /// <summary>
    /// Класс определяет персону
    /// </summary>
    public class Person : ICloneable
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
        /// Рассказывает о себе
        /// </summary>
        virtual public string TellAbout()
        {
            string speaking = $"Меня зовут {Name}, ";
            string gender = "";
            switch (Gender)
            {
                case 1:
                    gender = "я мужчина";
                    break;
                case 2:
                    gender = "я женщина";
                    break;
            }
            speaking = $@"Меня зовут {Name}
            {gender}";
            return speaking;
        }
        /// <summary>
        /// Создает новый объект класса <see cref="T:Lab10.Person"/>
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <param name="gender">Пол объекта</param>
        public Person(string name, int gender)
        {
            Name = name;
            Gender = gender;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
