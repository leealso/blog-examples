using System.Collections.Generic;
using TheoryTestCustomDataAttribute.Models;

namespace TheoryTestCustomDataAttribute.Services
{
    public interface ICourseService
    {
        bool Enroll(Student student);

        int Enroll(List<Student> group);
    }
}
