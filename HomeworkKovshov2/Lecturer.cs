﻿using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace HomeworkKovshov2
{
    /// <summary>
    /// Класс Лектор - реализация человека
    /// </summary>
    [Serializable]
    public class Lecturer : Persona
    {
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public DateTime DateOfBirth { get; set; }
        [XmlAttribute] public string Faculty { get; set; }
        [XmlAttribute] public string Position { get; set; }
        [XmlAttribute] public int Experience { get; set; }

        /// <summary>
        /// Конструктор класса Лектор
        /// </summary>
        /// <param name="name">Фамилия</param>
        /// <param name="day">День рождения</param>
        /// <param name="mon">Месяц рождения</param>
        /// <param name="year">Год рождения</param>
        /// <param name="faculty">Факультет</param>
        /// <param name="position">Должность</param>
        /// <param name="experience">Стаж</param>
        public Lecturer(string name, int day, int mon, int year, string faculty, string position, int experience)
        {
            Trace.WriteLine("Lecturer constructor");
            Name = name;
            DateOfBirth = new DateTime(year, mon, day);
            Faculty = faculty;
            Position = position;
            Experience = experience;
        }

        public Lecturer()
        {
        }

        public override void WriteInfo()
        {
            Trace.WriteLine("Lecturer.writeInfo()");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Date of birth: " + DateOfBirth.ToShortDateString());
            Console.WriteLine("Faculty: " + Faculty);
            Console.WriteLine("Position: " + Position);
            Console.WriteLine("Experience: " + Experience + "\n");
        }

        public override int GetAge()
        {
            Trace.WriteLine("Lecturer.getAge()");
            return Int32.Parse(DateTime.Today.AddYears(-DateOfBirth.Year).ToString("yyyy"));
        }
    }
}