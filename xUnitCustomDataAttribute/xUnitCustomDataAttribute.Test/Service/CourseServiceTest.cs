using System.Collections.Generic;
using Moq;
using TheoryTestCustomDataAttribute.Data;
using TheoryTestCustomDataAttribute.Models;
using TheoryTestCustomDataAttribute.Services;
using Xunit;

namespace xUnitCustomDataAttribute.Test.Service
{
    public class CourseServiceTest
    {
        private Mock<ICourseRepository> _repositoryMock;
        private CourseService _service;

        public CourseServiceTest()
        {
            _repositoryMock = new Mock<ICourseRepository>();
            _service = new CourseService(_repositoryMock.Object);
        }

        [Theory]
        [JsonFileData("Service/TestData.json", "Student")]
        public void EnrollStudent_Success(Student student)
        {
            _repositoryMock.Setup(x => x.GetStudent(student)).Returns((Student)null);
            _repositoryMock.Setup(x => x.Enroll(student)).Returns(true);

            var result = _service.Enroll(student);

            Assert.Equal(true, result);
        }

        [Theory]
        [JsonFileData("Service/TestData.json", "Student")]
        public void EnrollStudent_Failed(Student student)
        {
            _repositoryMock.Setup(x => x.GetStudent(student)).Returns(student);

            var result = _service.Enroll(student);

            Assert.Equal(false, result);
        }

        [Theory]
        [JsonFileData("Service/TestData.json", "Group")]
        public void EnrollGroup_Success(List<Student> students, int expected)
        {
            _repositoryMock.Setup(x => x.Enroll(It.IsAny<Student>())).Returns(true);
            _repositoryMock.SetupSequence(x => x.GetStudent(It.IsAny<Student>()))
                           .Returns((Student)null)
                           .Returns(new Student())
                           .Returns((Student)null)
                           .Returns(new Student())
                           .Returns((Student)null)
                           .Returns(new Student());

            var result = _service.Enroll(students);

            Assert.Equal(expected, result);
        }
    }
}
