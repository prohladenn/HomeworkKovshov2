using System.Xml.Serialization;

namespace HomeworkKovshov2
{
    /// <summary>
    /// Абстрктный класс Человек
    /// </summary>
    [XmlInclude(typeof(Applicant)),XmlInclude(typeof(Student)),XmlInclude(typeof(Lecturer))]
    public abstract class Persona
    {
        /// <summary>
        /// Выводит в консоль информацию о человеке
        /// </summary>
        public abstract void WriteInfo();
        /// <summary>
        /// Возвращает возраст человека
        /// </summary>
        /// <returns>Возраст</returns>
        public abstract int GetAge();
    }
}