using System;
using System.Collections.Generic;
using System.Linq;
using Lab13;

namespace Lab14
{
    public class Program
    {
        public static List<Person> Univercity { get { return _univercity; } }
        private static List<Person> _univercity; 
        public static List<Person> Faculty { get { return _faculty; } }
        private static List<Person> _faculty;
        static string[] menuElements = {
            ""
        };
        static Menu menu = new Menu(menuElements);

        static void Initialize()
        {
            _univercity = new List<Person>();
            _faculty = new List<Person>();
        }

        public static void Main(string[] args)
        {
            Initialize();
            

        }


    }
}
