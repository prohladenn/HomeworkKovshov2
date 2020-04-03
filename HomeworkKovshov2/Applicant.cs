﻿using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace HomeworkKovshov2
{
    /// <summary>
    /// Класс Абитуриент - реализация человека
    /// </summary>
    [Serializable]
    public class Applicant : Persona
    {
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public DateTime DateOfBirth { get; set; }
        [XmlAttribute] public string Faculty { get; set; }

        /// <summary>
        /// Конструктор класса Абитуриент
        /// </summary>
        /// <param name="name">Фамилия</param>
        /// <param name="day">День рождения</param>
        /// <param name="mon">Месяц рождения</param>
        /// <param name="year">Год рождения</param>
        /// <param name="faculty">Факультет</param>
        public Applicant(string name, int day, int mon, int year, string faculty)
        {
            Trace.WriteLine("Applicant constructor");
            Name = name;
            DateOfBirth = new DateTime(year, mon, day);
            Faculty = faculty;
        }

        public Applicant()
        {
        }

        public override void WriteInfo()
        {
            Trace.WriteLine("Applicant.writeInfo()");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Date of birth: " + DateOfBirth.ToShortDateString());
            Console.WriteLine("Faculty: " + Faculty + "\n");
        }

        public override int GetAge()
        {
            Trace.WriteLine("Applicant.getAge()");
            return Int32.Parse(DateTime.Today.AddYears(-DateOfBirth.Year).ToString("yyyy"));
        }
    }
}