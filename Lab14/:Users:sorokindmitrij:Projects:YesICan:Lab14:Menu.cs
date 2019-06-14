using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    class Menu
    {
        public void MainMenu()
        {
            string[] items = {"Добавить", "Удалить", "Показать", "Названия пароходов в порту",
                "Количество корабей в порту с включенным двигателем",
                "Количество корабей в море с включенным двигателем (Метод расширеня)",
                "Все корветы", "Площадь всех кораблей", "Выход"};

            bool end = false;
            while (!end)
            {
                string headline = $"Кораблей в море: {Program.SeaShips.Count}\t" +
                    $"Кораблей в порту:{Program.PortShips.Count}";

                int choice = ConsoleMenu.Show(headline, items);
                switch (choice)
                {
                    case 0: AddMenu(); break;
                    case 1: RemoveMenu(); break;
                    case 2: ShowMenu(); break;
                    case 3: NameSteamshipInPortMenu(); break;
                    case 4: NumberOfShipInPortRunEnginMenu(); break;
                    case 5: NumberOfShipInSeaRunEnginMenu(); break;
                    case 6: AllCorvetteMenu(); break;
                    case 7: SquareMenu(); break;
                    case 8: end = true; break;
                }
            }
        }

        private void AddMenu()
        {
            string headline = "Куда добавить?";
            string[] items = { "В порт", "В море", "Назад" };

            int choice = ConsoleMenu.Show(headline, items);
            switch (choice)
            {
                case 0: Program.PortShips.Add(NewShip()); break;
                case 1: Program.SeaShips.Add(NewShip()); break;
                case 2: return;
            }
        }
        private void RemoveMenu()
        {
            string headline = "Откуда удалить?";
            string[] items = { "Из порта", "Из моря", "Назад" };

            int choice = ConsoleMenu.Show(headline, items);
            switch (choice)
            {
                case 0: RemoveShip(Program.PortShips); break;
                case 1: RemoveShip(Program.SeaShips); break;
                case 2: return;
            }
        }
        private void RemoveShip(List<Ship> ships)
        {
            if(ships.Count==0)
            {
                Console.WriteLine("Коллекция пуста");
                Console.ReadKey();
                return;
            }

            string headline = "Какой элемент удалить?";
            List<string> items = ShipsToString(ships.ToArray()).ToList();
            int choice = ConsoleMenu.Show(headline, items.ToArray());

            ships.RemoveAt(choice);
        }
        private void ShowMenu()
        {
            Console.WriteLine("В порту:\n");
            if (Program.PortShips.Count == 0)
                Console.WriteLine("Коллекция пуста");
            else foreach (Ship ship in Program.PortShips)
            {
                Console.WriteLine(ship.Show() + "\n");
            }

            Console.WriteLine("\n\nВ Море:\n");
            if (Program.SeaShips.Count == 0)
                Console.WriteLine("Коллекция пуста");
            else foreach (Ship ship in Program.SeaShips)
            {
                Console.WriteLine(ship.Show() + "\n");
            }

            Console.ReadKey();
        }
        private void NameSteamshipInPortMenu()
        {
            string[] names = Program.GetNameOfSteamshipsInPort();
            if(names.Length==0)
            {
                Console.WriteLine("В порту нет пароходов");
                Console.ReadKey();
                return;
            }
            foreach (string s in names)
            {
                Console.WriteLine(s + "\n");
            }
            Console.ReadLine();
        }
        private void NumberOfShipInPortRunEnginMenu()
        {
            Console.WriteLine("Количество кораблей в порту с включенным двигателем: " +
                Program.GetNumberOfShipsInPortWithRunEngine());
            Console.ReadKey();
        }
        private void NumberOfShipInSeaRunEnginMenu()
        {
            Console.WriteLine("Количество кораблей в море с включенным двигателем: " +
                Program.GetNumberOfShipsInSeaWithRunEngine());
            Console.ReadKey();
        }
        private void AllCorvetteMenu()
        {
            Corvette[] corvettes = Program.GetAllCorvette();
            if (corvettes.Length == 0)
            {
                Console.WriteLine("Нет корветов");
                Console.ReadKey();
                return;
            }
            foreach(Corvette corvette in corvettes)
            {
                Console.WriteLine(corvette.Show()+"\n");
            }
            Console.ReadKey();
        }
        private void SquareMenu()
        {
            Console.WriteLine("Площадь всех кораблей: "+Program.GetSquareAllShips());
            Console.ReadKey();
        }

        private string[] ShipsToString(Ship[] ships)
        {
            var stringRes = from ship in ships
                      select ship.Show();
            string[] res = stringRes.ToArray();
            return res;
        }
        private Ship NewShip()
        {
            string headline = "Введите тип";
            string[] items = { "Корабль", "Корвет", "Параход", "Парусник"};
            int choice = ConsoleMenu.Show(headline, items);
            Ship newShip = new Ship();
            switch (choice)
            {
                case 0: break;
                case 1: newShip = new Corvette(); break;
                case 2: newShip = new Steamship(); break;
                case 3: newShip = new Sailboat(); break;
            }

            Console.WriteLine("Введите название");
            newShip.Name = UpgradedConsole.GetStringNotEmpty();
            Console.WriteLine("Введите длину");
            newShip.Length = UpgradedConsole.GetInt(1);
            Console.WriteLine("Введите ширину");
            newShip.Width = UpgradedConsole.GetInt(1);
            Console.WriteLine("Двигатель запущен?");
            newShip.EngineRunning = UpgradedConsole.GetYesOrNo();

            return newShip;
        }
    }
}
