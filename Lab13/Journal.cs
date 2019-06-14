using System;
using System.Collections.Generic;
namespace Lab13
{
    /// <summary>
    /// Содержит информацию о всех происходящих событиях
    /// </summary>
    public class Journal
    {
        /// <summary>
        /// Список произошедших событий
        /// </summary>
        private List<JournalEntry> journalEntries = new List<JournalEntry>();
        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs args)
        {
            JournalEntry entry = new JournalEntry(args.Name, args.ChangeType, args.Sourse.ToString());
            journalEntries.Add(entry);
        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs args)
        {
            JournalEntry entry = new JournalEntry(args.Name, args.ChangeType, args.Sourse.ToString());
            journalEntries.Add(entry);
        }
        public void Print()
        {
            foreach (JournalEntry entry in journalEntries)
                Console.WriteLine(entry);
        }
        public override string ToString()
        {
            string result = "";
            foreach (JournalEntry entry in journalEntries)
                result += entry + "\n";
            return result;
        }
    }
}
