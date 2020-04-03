﻿using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace HomeworkKovshov2
{
    /// <summary>
    /// Класс Студент - реализация человека
    /// </summary>
    [Serializable]
    public class Student : Persona
    {
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public DateTime DateOfBirth { get; set; }
        [XmlAttribute] public string Faculty { get; set; }
        [XmlAttribute] public int Year { get; set; }

        /// <summary>
        /// Конструктор класса Студент
        /// </summary>
        /// <param name="name">Фамилия</param>
        /// <param name="day">День рождения</param>
        /// <param name="mon">Месяц рождения</param>
        /// <param name="yy">Год рождения</param>
        /// <param name="faculty">Факультет</param>
        /// <param name="year">Курс</param>
        public Student(string name, int day, int mon, int yy, string faculty, int year)
        {
            Trace.WriteLine("Student constructor");
            Name = name;
            DateOfBirth = new DateTime(yy, mon, day);
            Faculty = faculty;
            Year = year;
        }

        public Student()
        {
        }

        public override void WriteInfo()
        {
            Trace.WriteLine("Student.writeInfo()");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Date of birth: " + DateOfBirth.ToShortDateString());
            Console.WriteLine("Faculty: " + Faculty);
            Console.WriteLine("Year: " + Year + "\n");
        }

        public override int GetAge()
        {
            Trace.WriteLine("Student.getAge()");
            return Int32.Parse(DateTime.Today.AddYears(-DateOfBirth.Year).ToString("yyyy"));
        }
    }
}