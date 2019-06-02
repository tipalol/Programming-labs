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
        public Cleaner(string name, int gender, string job) : base (name, gender)
        {
            Job = job;
        }
    }
}
