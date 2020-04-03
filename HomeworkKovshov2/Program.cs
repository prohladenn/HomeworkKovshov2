using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace HomeworkKovshov2
{
    /// <summary>
    /// Класс, создающий базу (массив) из n человек, который выводит
    /// полную информацию из базы, а также организующий поиск людей,
    /// чей возраст попадает в заданный диапазон
    /// </summary>
    /// <remarks>
    /// Ввод: input.txt
    /// </remarks>
    public static class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        public static void Main(string[] args)
        {
            Trace.Indent();
            CreateTxt();
            var streamReader = new StreamReader(@"input.txt");
            var n = int.Parse(streamReader.ReadLine());
            var min = int.Parse(streamReader.ReadLine());
            var max = int.Parse(streamReader.ReadLine());
            var persona = ReadPersona(streamReader, n);

            Console.WriteLine("Список:");
            foreach (var item in persona) item.WriteInfo();
            var ages = GetPeopleByAge(persona, min, max);

            Console.WriteLine("Люди в возрасте от " + min + " до " + max + ":");
            foreach (var item in ages) item.WriteInfo();

            Serialization(persona);

            streamReader.Close();
            Trace.Flush();
        }

        /// <summary>
        /// Метод считывает данные из input файла и создаёт список людей
        /// </summary>
        /// <param name="streamReader"></param>
        /// <param name="n">Число людей</param>
        /// <returns>Список персон</returns>
        private static List<Persona> ReadPersona(TextReader streamReader, int n)
        {
            Trace.WriteLine("Main.ReadPersona()");
            var persona = new List<Persona>();
            for (var i = 0; i < n; i++)
            {
                switch (streamReader.ReadLine())
                {
                    case "Applicant":
                        persona.Add(new Applicant(streamReader.ReadLine(),
                            int.Parse(streamReader.ReadLine()),
                            int.Parse(streamReader.ReadLine()),
                            int.Parse(streamReader.ReadLine()),
                            streamReader.ReadLine()));
                        break;
                    case "Student":
                        persona.Add(new Student(streamReader.ReadLine(),
                            int.Parse(streamReader.ReadLine()),
                            int.Parse(streamReader.ReadLine()),
                            int.Parse(streamReader.ReadLine()),
                            streamReader.ReadLine(),
                            int.Parse(streamReader.ReadLine())));
                        break;
                    case "Lecturer":
                        persona.Add(new Lecturer(streamReader.ReadLine(),
                            int.Parse(streamReader.ReadLine()),
                            int.Parse(streamReader.ReadLine()),
                            int.Parse(streamReader.ReadLine()),
                            streamReader.ReadLine(),
                            streamReader.ReadLine(),
                            int.Parse(streamReader.ReadLine())));
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }
            }

            return persona;
        }

        /// <summary>
        /// Возвращает людей, чей возраст попадает в определённый диапазон
        /// </summary>
        /// <param name="list">Список людей</param>
        /// <param name="min">Минимальный возраст</param>
        /// <param name="max">Максимальный возраст</param>
        /// <returns>Список людей, чей возраст между min и max</returns>
        private static IEnumerable<Persona> GetPeopleByAge(IEnumerable<Persona> list, int min, int max)
        {
            Trace.WriteLine("Main.GetPeopleByAge()");

            return list.Where(man => man.GetAge() >= min && man.GetAge() <= max).ToList();
        }

        /// <summary>
        /// Сериализация в файл output.txt
        /// </summary>
        /// <param name="personas">Массив людей</param>
        private static void Serialization(IEnumerable<Persona> personas)
        {
            Trace.WriteLine("Main.Serialization");
            var serializer = new XmlSerializer(typeof(Persona));
            var streamWriter = new StreamWriter(@"output.txt");
            foreach (var item in personas) serializer.Serialize(streamWriter, item);

            streamWriter.Close();
        }

        /// <summary>
        /// Создание input файла
        /// </summary>
        private static void CreateTxt()
        {
            Trace.WriteLine("Main.CreateTxt");
            var streamWriter = new StreamWriter(@"input.txt");
            streamWriter.WriteLine("3");
            streamWriter.WriteLine("29");
            streamWriter.WriteLine("40");
            streamWriter.WriteLine("Applicant");
            streamWriter.WriteLine("Dolgopolov");
            streamWriter.WriteLine("6");
            streamWriter.WriteLine("10");
            streamWriter.WriteLine("1997");
            streamWriter.WriteLine("IKNT");
            streamWriter.WriteLine("Student");
            streamWriter.WriteLine("Ginovyan");
            streamWriter.WriteLine("23");
            streamWriter.WriteLine("04");
            streamWriter.WriteLine("1990");
            streamWriter.WriteLine("IPMM");
            streamWriter.WriteLine("4");
            streamWriter.WriteLine("Lecturer");
            streamWriter.WriteLine("Selegey");
            streamWriter.WriteLine("9");
            streamWriter.WriteLine("05");
            streamWriter.WriteLine("1950");
            streamWriter.WriteLine("GI");
            streamWriter.WriteLine("Professor");
            streamWriter.WriteLine("30");
            streamWriter.Close();
        }
    }
}