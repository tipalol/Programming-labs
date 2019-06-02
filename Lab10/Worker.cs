//
//  Worker.cs
//  Worker
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
namespace Lab10
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
