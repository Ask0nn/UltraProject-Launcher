using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.IO;

namespace UltraProject.Services
{
    /// <summary>
    /// Контроллер для управления файлами с настройками в формате json
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class SettingsController<T>
    {
        #region Свойства
        public T Settings { get; set; }
        public string PathToJsonFile { get; private set; }
        #endregion

        /// <summary>
        /// Контроллер для управления файлами с настройками в формате json
        /// </summary>
        /// <param name="pathToJsonFile">птуь к файлу</param>
        public SettingsController(string pathToJsonFile)
        {
            OpenSettings(pathToJsonFile);
        }

        #region Методы
        /// <summary>
        /// Открытие файла настроек
        /// </summary>
        public void OpenSettings()
        {
            if (string.IsNullOrEmpty(PathToJsonFile))
                throw new NullReferenceException("Не указан путь к файлу");

            if (!File.Exists(PathToJsonFile))
                throw new FileNotFoundException("Файл настроек не найден\n" + PathToJsonFile, PathToJsonFile);

            var json = File.ReadAllText(PathToJsonFile);
            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException("Файл пуст");

            Settings = JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// Сохранение файла настроек
        /// </summary>
        public void SaveSettings()
        {
            if (string.IsNullOrEmpty(PathToJsonFile))
                throw new NullReferenceException("Не указан путь к файлу");

            if (!File.Exists(PathToJsonFile))
                throw new FileNotFoundException("Файл настроек не найден\n" + PathToJsonFile, PathToJsonFile);

            var json = JsonConvert.SerializeObject(Settings);
            File.WriteAllText(PathToJsonFile, json);
        }
        /// <summary>
        /// Открытие файла настроек
        /// </summary>
        /// <param name="pathToJsonFile">путь к файлу</param>
        public void OpenSettings(string pathToJsonFile)
        {
            if (string.IsNullOrEmpty(pathToJsonFile))
                throw new NullReferenceException("Не указан путь к файлу");

            PathToJsonFile = pathToJsonFile;

            if (!File.Exists(PathToJsonFile))
                throw new FileNotFoundException("Файл настроек не найден\n" + PathToJsonFile, PathToJsonFile);

            var json = File.ReadAllText(PathToJsonFile);
            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException("Файл пуст");

            Settings = JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// Сохранение файла настроек
        /// </summary>
        /// <param name="pathToJsonFile">путь к файлу</param>
        public void SaveSettings(string pathToJsonFile)
        {
            if (string.IsNullOrEmpty(pathToJsonFile))
                throw new NullReferenceException("Не указан путь к файлу");

            PathToJsonFile = pathToJsonFile;

            if (!File.Exists(PathToJsonFile))
                throw new FileNotFoundException("Файл настроек не найден\n" + PathToJsonFile, PathToJsonFile);

            var json = JsonConvert.SerializeObject(Settings);
            File.WriteAllText(PathToJsonFile, json);
        }
        #endregion
    }
}
