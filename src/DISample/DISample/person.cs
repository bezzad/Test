namespace DISample
{
    public class Person : IEquatable<Person>, IComparable<Person>
    {
        public string Name;
        public int Age;
        public int ID;

        public Person(string name, int age, int id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        public int CompareTo(Person other)
        {
            return Equals(other) ? 0 : -1;
        }

        public bool Equals(Person other)
        {
            return Name == other.Name &&
                Age == other.Age &&
                ID == other.ID;
        }
    }
}
