using System;
namespace Lab13
{
    public class NewUnivercityWorkers : UnivercityWorkers
    {
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;
        public string Name { get; set; }
        static int count = 0;
        public bool Remove(int j)
        {
            try
            {
                count--;
                if (Name != "Вторая")
                    CollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Удаление элемента", People[j]));
                    People.RemoveAt(j);

                return true;
            } catch (IndexErrorException e)
            {

                return false;
            }
        }
        public new Person this[int index]
        {
            get
            {
                return People[index];
            }
            set
            {
                People[index] = value;
                CollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "Ссылка на объект изменена", value));
            }
        }
        public new void FillRandom(int index)
        {
            count = index;
            try
            {
                if (Name != "Вторая")
                    CollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Заполнение случайными элементами", this));
                base.FillRandom(index);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message + " " + this);
            }
        }
        public new void Add(Person person)
        {
            count++;
            if (Name != "Вторая")
                CollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Добавление нового элемента", person));
            base.Add(person);
        }
        public NewUnivercityWorkers(string name)
        {
            Name = name;
        }
    }
}
