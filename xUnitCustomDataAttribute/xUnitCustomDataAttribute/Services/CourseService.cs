using System.Collections.Generic;
using TheoryTestCustomDataAttribute.Data;
using TheoryTestCustomDataAttribute.Models;

namespace TheoryTestCustomDataAttribute.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public bool Enroll(Student student)
        {
            if (!IsStudentEnrolled(student) && _repository.Enroll(student)) 
            {
                return true;
            }
            return false;
        }

        public int Enroll(List<Student> students)
        {
            var enrolledStudents = 0;
            foreach (var student in students)
            {
                if (Enroll(student))
                {
                    enrolledStudents++;
                }
            }
            return enrolledStudents;
        }

        private bool IsStudentEnrolled(Student student) 
        {
            return _repository.GetStudent(student) != null;
        }
    }
}
