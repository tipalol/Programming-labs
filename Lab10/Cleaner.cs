//
//  Cleaner.cs
//  Cleaner
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab10
{
    /// <summary>
    /// Класс определяет уборщика
    /// </summary>
    public class Cleaner : Person, IWorker
    {
        /// <summary>
        /// Получает или устанавливает должность
        /// </summary>
        /// <value>Должность</value>
        public string Job { get; set; }
        /// <summary>
        /// Рассказывает о себе
        /// </summary>
        public override string TellAbout()
        {
            return base.TellAbout() + $@",
            и я работаю в клининговой компании на должности {Job}";
        }
        public Cleaner(string name, int gender, string job) : base (name, gender)
        {
            Job = job;
        }
    }
}
