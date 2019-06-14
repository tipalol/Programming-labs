using System;
namespace Lab13
{
    /// <summary>
    /// Элемент журнала, содержащий информацию о произошедшем событии
    /// </summary>
    public class JournalEntry
    {
        /// <summary>
        /// Получает или устанавливает имя коллекции, в которой произошло изменение
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Получает или устанавливает тип произошедщего изменения
        /// </summary>
        /// <value>The type of the change.</value>
        public string ChangeType { get; set; }
        /// <summary>
        /// Получает или устанавливает объект с котороым связаны изменения
        /// </summary>
        /// <value>The source.</value>
        public string Sourse { get; set; }
        public override string ToString()
        {
            return $"Имя коллекции: {Name}, тип изменений: {ChangeType}, вызвавший: {Sourse}";
        }
        public JournalEntry(string name, string changeType, string sourse)
        {
            Name = name;
            ChangeType = changeType;
            Sourse = sourse;
        }
    }
}
