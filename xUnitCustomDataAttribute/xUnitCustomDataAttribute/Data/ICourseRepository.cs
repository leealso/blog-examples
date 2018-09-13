using System.Collections.Generic;
using TheoryTestCustomDataAttribute.Models;

namespace TheoryTestCustomDataAttribute.Data
{
    public interface ICourseRepository
    {
        bool Enroll(Student student);

        Student GetStudent(Student student);
    }
}
