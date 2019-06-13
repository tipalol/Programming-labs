//
//  IWorker.cs
//  IWorker
//
//  Created by Сорокин Дмитрий on 13/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab12
{
    /// <summary>
    /// Интерфейс реализует стандартного работника
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// Получает должность
        /// </summary>
        /// <value>Должность</value>
        string Job { get; set; }

    }
}
