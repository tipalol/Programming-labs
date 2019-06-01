using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab8
{
    /// <summary>
    /// Реализует работу с файлами
    /// Используется паттерн проектирования <see langword="Singlenton"/>
    /// </summary>
    public class DatabaseWorker
    {
        #region Модель
        /// <summary>
        /// Единственный объект класса
        /// </summary>
        private static DatabaseWorker instance;
        /// <summary>
        /// Создает нвоый объект <see cref="T:Lab8.DatabaseWorker"/>
        /// </summary>
        private DatabaseWorker(string path = "Data.bin") {
            binaryFormatter = new BinaryFormatter();
            Path = path;
         }
        /// <summary>
        /// Возвращает единственный объект класса
        /// </summary>
        /// <returns>Единственный объект класса</returns>
        public static DatabaseWorker GetInstance()
        {
            if (instance == null)
                instance = new DatabaseWorker();
            return instance;
        }
        /// <summary>
        /// Строка, содержащая путь к файлу базы данных
        /// </summary>
        /// <value>Путь к файлу базы данных</value>
        private string Path { get; set; }
        /// <summary>
        /// Файловый поток
        /// </summary>
        /// <value>Файловый поток</value>
        private FileStream fileStream { get; set; }
        /// <summary>
        /// Сериализирующий объект
        /// </summary>
        /// <value>Сериализирующий объект</value>
        private BinaryFormatter binaryFormatter { get; set; }
        #endregion
        #region Контроллер
        /// <summary>
        /// Проверяет, есть ли по указанному пути база данных
        /// </summary>
        /// <returns><c>true</c>, если по указанному пути удалось найти, <c>false</c> если не удалось</returns>
        public bool IsThereDatabase()
        {
            return File.Exists(Path);
        }
        /// <summary>
        /// Устанавливает путь к файлу
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void SetPath(string path) { Path = path; }
        /// <summary>
        /// Получает данные из файла базы данных
        /// </summary>
        /// <returns>Данные из файла базы данных или <see langword="null"/> если произошла ошибка</returns>
        public MeteoWorker GetData()
        {
            try
            {
                if (Path == "")
                {
                    Console.WriteLine("Путь к фалу не указан");
                    return null;
                } else
                {
                    fileStream = new FileStream(Path, FileMode.Open);
                    MeteoWorker meteoWorker = (MeteoWorker)binaryFormatter.Deserialize( fileStream );
                    fileStream.Close();
                    fileStream = null;
                    return meteoWorker;
                }
            } catch (Exception exception)
            {
                Console.WriteLine($"Произошла ошибка: {exception.Message}");
                return null;
            }
        }
        /// <summary>
        /// Сохраняет информацию в файл базы данных
        /// </summary>
        /// <param name="worker">Объект со всей информацией</param>
        public void SaveData(MeteoWorker worker)
        {
            try
            {
                if (Path == "")
                    Console.WriteLine("Путь к файлу не указан");
                else
                {
                    fileStream = new FileStream(Path, FileMode.Create);
                    binaryFormatter.Serialize( fileStream, worker );
                    fileStream.Close();
                    fileStream = null;
                }
            } catch (Exception exception)
            {
                Console.WriteLine($"Произошла ошибка: {exception.Message}");
            }
        }
        #endregion
    }
}
