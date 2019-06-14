using System;
namespace Lab13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string ChangeType { get; set; }
        public object Sourse { get; set; }
        public CollectionHandlerEventArgs(string name, string changeType, object sourse)
        {
            Name = name;
            ChangeType = changeType;
            Sourse = sourse;
        }
        public override string ToString()
        {
            return $"Название коллекции: {Name}, тип изменений: {ChangeType}, источник изменений: {Sourse}";
        }
    }
}
