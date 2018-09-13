namespace TheoryTestCustomDataAttribute.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student()
        {

        }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
